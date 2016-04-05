@ECHO OFF

DEL C:\Temp\7zDUMP\*.* /Q


SET RAWDATE=%DATE:~-10%
SET MM=%RAWDATE:~0,2%
SET DAYMON=%RAWDATE:~-7%
SET DD=%DAYMON:~0,2%
SET YYYY=%RAWDATE:~-4%

SET POSPATH=%C:\Program Files\SAP\Retail Systems\Point of Sale%
SET RIBPATH=%C:\Program Files\RedIron Technologies\RedIron Broker%
SET MCMPATH=%C:\MerchantConnectMulti%
SET MX9PATH=%C:\Program Files\VeriFone\MX915\UpdateFiles%
MKDIR C:\Temp\7zDUMP
SET TMPPATH=C:\Temp\7zDUMP\

:ZIPMCM
C:\
CD \TEMP
CD 7zDUMP


IF EXIST %TMPPATH%MCMLOG.7z DEL %TMPPATH%MCMLOG.7z
COPY "%MCMPATH%\log\*_%YYYY%%MM%%DD%.dg"
COPY "%MCMPATH%\log\multi_%YYYY%%MM%%DD%.log" 
COPY "%MCMPATH%\OUT\*_aid.cfg" 
COPY "%MCMPATH%\OUT\*_rid.cfg" 
COPY "%MCMPATH%\OUT\*_emv.cfg"

:ZIPRIB

IF EXIST %TMPPATH%RIBrokerLogs.7z DEL %TMPPATH%RIBrokerLogs.7z
taskkill /F /IM posw.exe
Net STOP RIBROKER
COPY "%POSPATH%\2Authorize.*" 
COPY "%RIBPATH%\RIBroker.log" 
COPY "%POSPATH%\UserExits.*" 
COPY "%POSPATH%\xcpt.log" 
Net START RIBROKER

:ZIPMX9

IF EXIST %TMPPATH%MX9Logs.7z DEL %TMPPATH%MX9Logs.7z
COPY "%MX9PATH%\logfiles\*.* 

C:\Windows\System32\WindowsPowerShell\v1.0\Powershell.exe C:\Temp\Zipper.ps1

::ZIPPER

::C:\TEMP\7ZA.EXE a -t7z %TMPPATH%CREDITLOGS.7z %TMPPATH%* 

EXIT 0