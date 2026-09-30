@echo off

net session >nul 2>&1
if %errorLevel% == 0 (
    echo Success: Administrative permissions confirmed.
) else (
    goto UACPrompt
)

REM Сначала зависимости (тоже подписаны строгим именем Microsoft — можно в GAC)
"%~dp0gacutil" /i "%~dp0Microsoft.Bcl.AsyncInterfaces.dll"
"%~dp0gacutil" /i "%~dp0System.Buffers.dll"
"%~dp0gacutil" /i "%~dp0System.Memory.dll"
"%~dp0gacutil" /i "%~dp0System.Numerics.Vectors.dll"
"%~dp0gacutil" /i "%~dp0System.Runtime.CompilerServices.Unsafe.dll"
"%~dp0gacutil" /i "%~dp0System.Text.Encodings.Web.dll"
"%~dp0gacutil" /i "%~dp0System.Text.Json.dll"
"%~dp0gacutil" /i "%~dp0System.Threading.Tasks.Extensions.dll"
"%~dp0gacutil" /i "%~dp0System.ValueTuple.dll"

REM Publisher policy: у System.Text.Json compile-time reference assembly имеет
REM версию 8.0.0.0, а в рантайме/GAC лежит 8.0.0.5 — .dll.config с bindingRedirect
REM не читается, когда сборка активируется как COM-сервер в чужом хосте (PowerShell, 1C),
REM поэтому редирект публикуется через policy-сборку в GAC.
"%~dp0gacutil" /i "%~dp0policy.8.0.System.Text.Json.dll"

REM Теперь сама сборка
"%~dp0gacutil" /i "%~dp0SkkmConnector.dll"

REM Только 32-битная регистрация (WOW6432Node) — для 32-битных хостов (1C x86 и т.п.)
"%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe" "%~dp0SkkmConnector.dll" /codebase /tlb

REM Binding redirects в machine.config: COM-хосты (1C, PowerShell, VBA и т.п.) не читают
REM SkkmConnector.dll.config, только общесистемный machine.config. Правим только 32-битный.
REM Скрипт только редактирует файл, разрядность PowerShell не важна. Из 32-битного процесса
REM (установщик Inno Setup) берём 64-битный PowerShell через Sysnative: 32-битный PowerShell
REM на части машин зависает при старте. На 32-битной Windows Sysnative нет — берём System32.
set "PS=%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe"
if exist "%SystemRoot%\Sysnative\WindowsPowerShell\v1.0\powershell.exe" set "PS=%SystemRoot%\Sysnative\WindowsPowerShell\v1.0\powershell.exe"
"%PS%" -ExecutionPolicy Bypass -NoProfile -NonInteractive -InputFormat None -File "%~dp0fix-binding-redirects.ps1" -X86Only < NUL

REM nopause — запуск из установщика (Inno Setup): без паузы, иначе скрытое окно зависнет
if /i "%~1"=="nopause" exit /b

echo.
echo Press any key to continue...
pause>nul
exit /b


:UACPrompt
mshta "vbscript:CreateObject(""Shell.Application"").ShellExecute(""%~fs0"", """", """", ""runas"", 1) & Close()"
exit /b