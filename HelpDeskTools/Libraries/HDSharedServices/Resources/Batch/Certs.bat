@ECHO OFF
REM
:importCertRoot
	verify >nul
	certutil.exe -store authroot | findstr "040000000001154b5ac394"
	IF '%ERRORLEVEL%'=='0' goto importCertRoot2
	verify >nul
	certutil -addstore -f "authroot" "C:\Temp\global.cer"

:importCertRoot2
	verify >nul
	certutil -store authroot | findstr "9b7e0649a33e62b9d5ee90487129ef57"
	IF '%ERRORLEVEL%'=='0' goto exit
	verify >nul
	certutil -addstore -f "authroot" "C:\Temp\verisign-root.cer"

:exit
ping -n 5 >nul
