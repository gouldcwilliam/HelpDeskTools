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
	CALL:WAIT
	CALL:WAIT
GOTO:DONE

:CREDIT
	IF %A%==start CALL:creditSTART
	IF %A%==stop CALL:creditSTOP
	IF %a%==restart (
		CALL:creditSTOP
		CALL:creditSTART
	)
GOTO:EOF
	
:creditSTART
	NET START "CDCA MULTI CLIENT"
	NET START "RIBROKER"
GOTO:EOF
	
	
:creditSTOP
	NET STOP "RIBROKER"
	NET STOP "CDCA MULTI CLIENT"
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
		CALL:creditSTOP
		CD "C:\Program Files\Verifone\MX915\vfQueryUpdate"
		ECHO Running vfQueryUpdate
		START /wait vfQueryUpdate.exe
		ECHO Done, now waiting for things to happen...... for 3 minutes
		PING 127.0.0.1 -n 60 > NUL
		ECHO 2 min...
		PING 127.0.0.1 -n 60 > NUL
		ECHO 1 min...
		PING 127.0.0.1 -n 60 > NUL
		CALL:creditSTART
	)
GOTO:EOF

:TRANSNET
	IF %A%==start CALL:transnetSTART
	IF %A%==stop CALL:transnetSTOP
	IF %a%==restart (
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

:KILL
	TASKKILL /IM "POSW.EXE" /F
GOTO:EOF

:WAIT
	PING 127.0.0.1 -n 6 > NUL
GOTO:EOF

:DONE