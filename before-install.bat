REM Install Internet Information Server (IIS).
REM c:\Windows\Sysnative\WindowsPowerShell\v1.0\powershell.exe -Command Import-Module -Name ServerManager
REM c:\Windows\Sysnative\WindowsPowerShell\v1.0\powershell.exe -Command Install-WindowsFeature Web-Server
mkdir c:\inetpub\HelloWebAPI                   > NUL 2>&1
del      /q c:\inetpub\HelloWebAPI\Web.config  > NUL 2>&1
del      /q c:\inetpub\HelloWebAPI\Global.asax > NUL 2>&1
rmdir /s /q c:\inetpub\HelloWebAPI\bin         > NUL 2>&1
