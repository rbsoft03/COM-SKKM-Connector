; Установщик SkkmConnector для 32-битных COM-хостов (1С x86, VBA x86 и т.п.).
; Копирует собранную папку коннектора и запускает reg_x86.bat, при удалении — unreg.bat.
;
; Сборка установщика:
;   "C:\Program Files (x86)\Inno Setup 6\ISCC.exe" SkkmConnector_x86.iss
; Другая папка сборки (например, Release):
;   ISCC.exe /DBuildDir="..\bin\Release\net48" SkkmConnector_x86.iss

#ifndef BuildDir
  #define BuildDir "..\bin\Debug\net48"
#endif

#define AppName      "SKKM COM Connector (x86)"
#define AppPublisher "RBSoft"
#define AppVersion   GetVersionNumbersString(AddBackslash(SourcePath) + BuildDir + "\SkkmConnector.dll")

[Setup]
AppId={{42C267F8-9CD1-4926-9EBD-948D36030280}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
; 32-битный режим установщика: папка по умолчанию — Program Files (x86)
DefaultDirName={autopf}\RBSoft\SkkmConnector
DisableProgramGroupPage=yes
; GAC, реестр (CLSID) и machine.config требуют прав администратора
PrivilegesRequired=admin
OutputDir=Output
OutputBaseFilename=SkkmConnector_x86_{#AppVersion}
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
UninstallDisplayName={#AppName}
; COM-сервер может держать запущенная 1С — предлагаем закрыть
CloseApplications=yes

[Languages]
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Files]
; Вся папка сборки, кроме отладочных символов и 64-битного reg.bat
Source: "{#BuildDir}\*"; DestDir: "{app}"; Excludes: "*.pdb,reg.bat"; Flags: ignoreversion recursesubdirs

[Run]
; Лог пишется в {app}\install.log — окно скрытое, иначе вывода не видно
Filename: "{cmd}"; Parameters: "/c """"{app}\reg_x86.bat"" nopause > ""{app}\install.log"" 2>&1"""; \
  WorkingDir: "{app}"; StatusMsg: "Регистрация COM-компонента..."; Flags: runhidden waituntilterminated

[UninstallRun]
Filename: "{cmd}"; Parameters: "/c """"{app}\unreg.bat"" nopause > ""{app}\uninstall.log"" 2>&1"""; \
  WorkingDir: "{app}"; RunOnceId: "UnregSkkmConnector"; Flags: runhidden waituntilterminated

[UninstallDelete]
Type: files; Name: "{app}\install.log"
Type: files; Name: "{app}\uninstall.log"
