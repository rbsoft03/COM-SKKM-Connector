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

REM Прямая проверка кодов маркировки (RBSoft.MarkingVerification) — тоже строго подписаны
"%~dp0gacutil" /i "%~dp0Newtonsoft.Json.dll"
"%~dp0gacutil" /i "%~dp0SkkmConnector.MarkingVerification.dll"

REM Теперь сама сборка
"%~dp0gacutil" /i "%~dp0SkkmConnector.dll"

"%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe" "%~dp0SkkmConnector.dll" /codebase /tlb
"%SystemRoot%\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe" "%~dp0SkkmConnector.dll" /codebase /tlb

REM Binding redirects в machine.config: COM-хосты (1C, PowerShell, VBA и т.п.) не читают
REM SkkmConnector.dll.config, только общесистемный machine.config.
powershell -ExecutionPolicy Bypass -NoProfile -File "%~dp0fix-binding-redirects.ps1"

echo.
echo Press any key to continue...
pause>nul
exit /b


:UACPrompt
mshta "vbscript:CreateObject(""Shell.Application"").ShellExecute(""%~fs0"", """", """", ""runas"", 1) & Close()"
exit /b