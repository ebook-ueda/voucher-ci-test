REM Install Internet Information Server (IIS).
REM c:\Windows\Sysnative\WindowsPowerShell\v1.0\powershell.exe -Command Import-Module -Name ServerManager
REM c:\Windows\Sysnative\WindowsPowerShell\v1.0\powershell.exe -Command Install-WindowsFeature Web-Server
mkdir c:\inetpub\HelloWebAPI > NUL 2>&1
del      /q c:\inetpub\HelloWebAPI\src\HelloWebAPI\Web.config
del      /q c:\inetpub\HelloWebAPI\src\HelloWebAPI\Global.asax
rmdir /s /q c:\inetpub\HelloWebAPI\src\HelloWebAPI\bin
