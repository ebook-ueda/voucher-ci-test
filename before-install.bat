mkdir c:\inetpub\HelloWebAPI     > NUL 2>&1
if exist c:\inetpub\HelloWebAPI\Web.config  del      /q c:\inetpub\HelloWebAPI\Web.config
if exist c:\inetpub\HelloWebAPI\Global.asax del      /q c:\inetpub\HelloWebAPI\Global.asax
if exist c:\inetpub\HelloWebAPI\bin         rmdir /s /q c:\inetpub\HelloWebAPI\bin
mkdir c:\inetpub\HelloWebAPI\bin
