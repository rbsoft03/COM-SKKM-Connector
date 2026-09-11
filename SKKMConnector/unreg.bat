@echo off
 
net session >nul 2>&1
if %errorLevel% == 0 (
    echo Success: Administrative permissions confirmed.
) else (
    goto UACPrompt
)
 
"%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe" "%~dp0SkkmConnector.dll" /unregister
"%SystemRoot%\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe" "%~dp0SkkmConnector.dll" /unregister
 
"%~dp0gacutil" /u "SkkmConnector"
"%~dp0gacutil" /u "policy.8.0.System.Text.Json"
"%~dp0gacutil" /u "Microsoft.Bcl.AsyncInterfaces"
"%~dp0gacutil" /u "System.Buffers"
"%~dp0gacutil" /u "System.Memory"
"%~dp0gacutil" /u "System.Numerics.Vectors"
"%~dp0gacutil" /u "System.Runtime.CompilerServices.Unsafe"
"%~dp0gacutil" /u "System.Text.Encodings.Web"
"%~dp0gacutil" /u "System.Text.Json"
"%~dp0gacutil" /u "System.Threading.Tasks.Extensions"
"%~dp0gacutil" /u "System.ValueTuple"
 
echo.
echo Press any key to continue...
pause>nul
exit /b
 
 
:UACPrompt
mshta "vbscript:CreateObject(""Shell.Application"").ShellExecute(""%~fs0"", """", """", ""runas"", 1) & Close()"
exit /b