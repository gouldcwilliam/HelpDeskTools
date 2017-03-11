@ECHO OFF

	SET A=%1
	SET S=%2
	ECHO %S% %A%
	
:BEGIN
	IF %S%==credit  CALL:CREDIT
	IF %S%==sql CALL:SQL
	IF %S%==pca CALL:PCA
	IF %S%==citrix CALL:CITRIX
	IF %S%==verifone CALL:VERIFONE
	IF %S%==transnet CALL:TRANSNET
	IF %S%==dameware CALL:DAMEWARE
	IF %S%==bit9 CALL:BIT9
	IF %S%==tripwire CALL:TRIPWIRE
	IF %S%==sep CALL:SEP
	CALL:WAIT
GOTO:DONE

:CREDIT
	IF %A%==start CALL:creditSTART
	IF %A%==stop CALL:creditSTOP
	IF %a%==restart (
		CALL:creditSTOP
		CALL:WAIT
		CALL:creditSTART
	)
GOTO:EOF
	
:creditSTART
	NET START "RIBROKER"
	NET START "CDCA MULTI CLIENT"
GOTO:EOF
	
	
:creditSTOP
	NET STOP "CDCA MULTI CLIENT"
	NET STOP "RIBROKER"
GOTO:EOF

:SQL
	IF %A%==start CALL:sqlSTART
	IF %A%==stop CALL:sqlSTOP
	IF %a%==restart (
		CALL:sqlSTOP
		CALL:sqlSTART
	)
GOTO:EOF

:sqlSTART
	NET START "MSSQLserver"
	NET START "XPRESS SERVER"

GOTO:EOF

:sqlSTOP
	NET STOP "XPRESS SERVER"
	NET STOP "MSSQLSERVER"
GOTO:EOF

:PCA
	IF %A%==start CALL:pcaSTART
	IF %A%==stop CALL:pcaSTOP
	IF %a%==restart (
		CALL:pcaSTOP
		CALL:WAIT
		CALL:pcaSTART
	)
GOTO:EOF

:pcaSTOP
	NET STOP "awhost32"
GOTO:EOF

:pcaSTART
	NET START "awhost32"
GOTO:EOF

:CITRIX
	IF %A%==stop (
		TASKKILL /IM "PNAMAIN.EXE" /F
	)
GOTO:EOF

:VERIFONE
	IF %A%==restart (
		CALL:KILL
		CALL:creditSTOP
		CD "C:\Program Files\Verifone\MX915\vfQueryUpdate"
		ECHO Running vfQueryUpdate
		START /wait vfQueryUpdate.exe
		ECHO Have the user monitor the verifone screen
		CALL:WAIT
	)
	IF %A%==refresh (
		CALL:KILL
		CALL:creditSTOP
		CD "C:\Program Files\Verifone\MX915\vfQueryUpdate"
		ECHO Running vfQueryUpdate
		START /wait vfQueryUpdate.exe
		PING 127.0.0.1 -n 60 > NUL
		CALL:creditSTART
	)
GOTO:EOF

:TRANSNET
	IF %A%==start CALL:transnetSTART
	IF %A%==stop CALL:transnetSTOP
	IF %A%==restart (
		CALL:transnetSTOP
		CALL:transnetSTART
	)
GOTO:EOF

:transnetSTART
	NET START "NFM CLIENT SERVICE"
	NET START "NTM JAVA CLIENT"
	NET START "TRANSNET"
GOTO:EOF

:transnetSTOP
	NET STOP "NFM CLIENT SERVICE"
	NET STOP "NTM JAVA CLIENT"
	NET STOP "TRANSNET"
GOTO:EOF

:DAMEWARE
	IF %A%==start CALL:damewareSTART
	IF %A%==stop CALL:damewareSTOP
	IF %A%==restart (
		CALL:damewareSTOP
		CALL:damewareSTART
	)
GOTO:EOF

:damewareSTART
	NET START DWMRCS
GOTO:EOF

:damewareSTOP
	NET STOP DWMRCS
GOTO:EOF

:BIT9
	IF %A%==start CALL:bit9START
	IF %A%==stop CALL:bit9STOP
	IF %A%==restart (
		CALL:bit9STOP
		CALL:bit9START
	)
GOTO:EOF

:bit9START
	NET START PARITY
GOTO:EOF

:bit9STOP
	NET STOP PARITY
GOTO:EOF

:TRIPWIRE
	IF %A%==start CALL:tripwireSTART
	IF %A%==stop CALL:tripwireSTOP
	IF %A%==restart (
		CALL:tripwireSTOP
		CALL:tripwireSTART
	)
GOTO:EOF

:tripwireSTART
	ECHO "Start TRIPPING"
	NET START TEAGENT
GOTO:EOF

:tripwireSTOP
	ECHO "Start TRIPPING"
	NET STOP TEAGENT
GOTO:EOF

:SEP
	IF %A%==start CALL:sepSTART
	IF %A%==stop CALL:sepSTOP
	IF %A%==restart (
		CALL:sepSTOP
		CALL:sepSTART
	)
GOTO:EOF

:sepSTART
	ECHO "Starting SEP"
	"c:\Program Files\Symantec\Symantec Endpoint Protection\smc" -start
GOTO:EOF

:sepSTOP
	ECHO "Stopping SEP"
	"c:\Program Files\Symantec\Symantec Endpoint Protection\smc" -p 5Ym4nT3c5Ym4nT3c -stop
GOTO:EOF

:KILL
	TASKKILL /IM "POSW.EXE" /F
GOTO:EOF

:WAIT
	PING 127.0.0.1 -n 6 > NUL
GOTO:EOF

:DONE