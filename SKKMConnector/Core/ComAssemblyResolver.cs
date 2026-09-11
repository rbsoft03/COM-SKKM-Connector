using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RBSoftSkkm;

/// <summary>
/// Разрешение зависимостей при активации через COM.
///
/// Когда объект создаётся не .NET-приложением, а классическим COM-хостом
/// (powershell.exe, 1С, VBA, VBScript), CLR берёт конфигурацию процесса-хоста,
/// а НЕ файл SkkmConnector.dll.config. Значит &lt;bindingRedirect&gt; из него игнорируются,
/// и загрузка зависимостей System.Text.Json (System.Runtime.CompilerServices.Unsafe,
/// System.Memory, System.Buffers и т.д.) падает с FileNotFoundException — наружу это
/// выходит как ошибка class factory 0x80070002 «Не удаётся найти указанный файл».
///
/// Здесь мы вешаем обработчик <see cref="AppDomain.AssemblyResolve"/>, который при
/// провале обычного поиска подгружает нужную сборку по короткому имени из папки, где
/// лежит сама SkkmConnector.dll (её путь известен из /codebase). Это заменяет
/// binding redirect'ы и работает в любом COM-хосте, конфиг которого мы не контролируем.
///
/// Регистрация выполняется в module initializer — он гарантированно отрабатывает
/// ДО статических конструкторов любых типов сборки, то есть до первого обращения
/// к System.Text.Json.
/// </summary>
internal static class ComAssemblyResolver
{
    private static int _installed;

    [ModuleInitializer]
    internal static void Install()
    {
        // Идемпотентно: подписываемся ровно один раз.
        if (System.Threading.Interlocked.Exchange(ref _installed, 1) != 0)
            return;

        AppDomain.CurrentDomain.AssemblyResolve += Resolve;
    }

    private static Assembly? Resolve(object? sender, ResolveEventArgs args)
    {
        var requested = new AssemblyName(args.Name);
        var simpleName = requested.Name;

        if (string.IsNullOrEmpty(simpleName))
            return null;

        // Ресурсные сателлиты (.resources) не грузим — пусть решает штатный механизм.
        if (simpleName!.EndsWith(".resources", StringComparison.OrdinalIgnoreCase))
            return null;

        // Если сборка с таким коротким именем уже загружена в домен (возможно, другой
        // версии) — отдаём её. Это и есть эффект отсутствовавшего binding redirect.
        foreach (var loaded in AppDomain.CurrentDomain.GetAssemblies())
        {
            if (string.Equals(loaded.GetName().Name, simpleName, StringComparison.OrdinalIgnoreCase))
                return loaded;
        }

        // Иначе ищем <simpleName>.dll рядом с нашей сборкой.
        var baseDir = GetAssemblyDirectory();
        if (baseDir == null)
            return null;

        var candidate = Path.Combine(baseDir, simpleName + ".dll");
        if (!File.Exists(candidate))
            return null;

        try
        {
            return Assembly.LoadFrom(candidate);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>Папка, из которой реально загружена SkkmConnector.dll (учитывает /codebase).</summary>
    private static string? GetAssemblyDirectory()
    {
        var asm = typeof(ComAssemblyResolver).Assembly;

        // Location пуст для сборок, загруженных из байтов; тогда падаем на CodeBase.
        var location = asm.Location;
        if (!string.IsNullOrEmpty(location))
            return Path.GetDirectoryName(location);

        try
        {
#pragma warning disable SYSLIB0012 // CodeBase устарел, но на net48 это рабочий запасной путь.
            var codeBase = asm.CodeBase;
#pragma warning restore SYSLIB0012
            if (!string.IsNullOrEmpty(codeBase))
            {
                var uri = new Uri(codeBase);
                return Path.GetDirectoryName(uri.LocalPath);
            }
        }
        catch
        {
            // ignore
        }

        return null;
    }
}
