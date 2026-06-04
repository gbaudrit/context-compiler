#define MyAppName "ContextCompiler"
#define MyAppVersion GetEnv("CTX_VERSION")
#define MyAppPublisher "Guillaume Baudrit"
#define MyAppURL "https://contextcompiler.io"
#define MyAppRepoURL "https://github.com/gbaudrit/context-compiler"
#define MyAppExeName "ctxc.exe"

#if MyAppVersion == ""
  #define MyAppVersion "0.1.0"
#endif

; Strip any SemVer suffix (e.g. "-alpha", "-rc1") for Win32 VersionInfo, which requires X.Y.Z[.W].
#define MyAppNumericVersion MyAppVersion
#if Pos("-", MyAppNumericVersion) > 0
  #define MyAppNumericVersion Copy(MyAppNumericVersion, 1, Pos("-", MyAppNumericVersion) - 1)
#endif
#if Pos("+", MyAppNumericVersion) > 0
  #define MyAppNumericVersion Copy(MyAppNumericVersion, 1, Pos("+", MyAppNumericVersion) - 1)
#endif

[Setup]
AppId={{A5F8A2DB-2E4B-4C31-A2A1-7C0D5E9F1B23}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppRepoURL}/issues
AppUpdatesURL={#MyAppRepoURL}/releases
DefaultDirName={autopf}\ContextCompiler
DefaultGroupName=ContextCompiler
DisableProgramGroupPage=yes
OutputDir=..\..\artifacts
OutputBaseFilename=ContextCompiler-Setup-{#MyAppVersion}
Compression=lzma
SolidCompression=yes
WizardStyle=modern
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
PrivilegesRequired=lowest
ChangesEnvironment=yes
UninstallDisplayIcon={app}\ctxc.exe
VersionInfoVersion={#MyAppNumericVersion}
VersionInfoCompany={#MyAppPublisher}
VersionInfoDescription=ContextCompiler CLI Setup
VersionInfoProductName={#MyAppName}

; Optional signature hook. Enable when you have a certificate.
; SignTool=signtool sign /tr http://timestamp.digicert.com /td sha256 /fd sha256 /a $f

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"

[Tasks]
Name: "addpath"; Description: "Add ContextCompiler to PATH"; GroupDescription: "Command line integration:"; Flags: checkedonce

[Files]
Source: "..\..\publish\win-x64\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\ContextCompiler CLI"; Filename: "{app}\ctxc.exe"
Name: "{group}\Uninstall ContextCompiler"; Filename: "{uninstallexe}"

[Registry]
Root: HKCU; Subkey: "Environment"; ValueType: expandsz; ValueName: "Path"; ValueData: "{olddata};{app}"; Check: NeedsAddPath(ExpandConstant('{app}')) and WizardIsTaskSelected('addpath'); Flags: preservestringtype

[Run]
Filename: "{cmd}"; Parameters: "/C setx PATH ""%PATH%;{app}"""; Flags: runhidden; Check: WizardIsTaskSelected('addpath') and NeedsAddPath(ExpandConstant('{app}'))

[Code]
function NeedsAddPath(Param: string): boolean;
var
  OrigPath: string;
begin
  if not RegQueryStringValue(HKEY_CURRENT_USER, 'Environment', 'Path', OrigPath) then
  begin
	Result := True;
	exit;
  end;

  Result := Pos(';' + Uppercase(Param) + ';', ';' + Uppercase(OrigPath) + ';') = 0;
end;
