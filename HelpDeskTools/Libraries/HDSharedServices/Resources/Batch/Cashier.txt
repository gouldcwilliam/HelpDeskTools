@ECHO OFF

:: ===================================
::      UNLOCK POWERUSER ACCOUNTS
:: ===================================

:VARIABLES
	SET EMPNUM=%1
	SET RAWDATE=%DATE:~-10%
	SET YYYY=%RAWDATE:~-4%
	SET MM=%RAWDATE:~0,2%
	SET DAYMON=%RAWDATE:~-7%
	SET DD=%DAYMON:~0,2%
	SET DSPACE=0
	IF "%DAYMON:~0,1%"==" " SET DD=%DSPACE%%DAYMON:~1,1%
	SET RAWTIME=%TIME:~0,5%
	SET HH=%RAWTIME:~0,2%
	SET HSPACE=0
	IF "%RAWTIME:~0,1%"==" " SET HH=%HSPACE%%RAWTIME:~1,1%
	SET MN=%RAWTIME:~3%
	SET MSPACE=0
	IF "%RAWTIME:~3,1%"==" " SET MN=%MSPACE%%RAWTIME:~4%
	SET TRGPATH=C:\Temp
	IF NOT EXIST %TRGPATH%\EMPAUDIT\ MKDIR %TRGPATH%\EmpAudit\
	SET EMPPATH=C:\Temp\EmpAudit

:PREUNLOK
	sqlcmd -E -S 127.0.0.1 -o C:\Temp\EmpAudit\useraudit_BEFORE.txt -Q "USE backoff; SELECT empnum, failed_attempts, password, newpasswordreqd, passwd_set, passwd_use FROM employee WHERE empnum = %EMPNUM%"
	IF NOT EXIST %EMPPATH%\useraudit_BEFORE.txt (
		SET ERRORLEVEL=1
		GOTO EXITNOW
	) ELSE (
		COPY /Y %EMPPATH%\useraudit_BEFORE.txt %EMPPATH%\useraudit%YYYY%%MM%%DD%_BEFORE.txt
	)

:UNLOCK
	sqlcmd -E -S 127.0.0.1 -e -Q "use backoff; update employee SET passwd_set = '$(RAWDATE)' WHERE empnum = %EMPNUM%"
	sqlcmd -E -S 127.0.0.1 -e -Q "declare @datetime datetime; select @datetime = CONVERT(VARCHAR(20),getdate(), 120); use backoff; update employee SET passwd_use = @datetime where empnum = %EMPNUM%"
	sqlcmd -E -S 127.0.0.1 -e -Q "use backoff; update employee SET failed_attempts = '0' WHERE empnum = %EMPNUM%"
	sqlcmd -E -S 127.0.0.1 -e -Q "use backoff; update employee SET newpasswordreqd = 'N' WHERE empnum = %EMPNUM%"

:PSTUNLOK
	sqlcmd -E -S 127.0.0.1 -o C:\Temp\EmpAudit\useraudit_AFTER.txt -Q "USE backoff; SELECT empnum, failed_attempts, password, newpasswordreqd, passwd_set, passwd_use FROM employee WHERE empnum = %EMPNUM%"
	IF NOT EXIST %EMPPATH%\useraudit_AFTER.txt (
		GOTO EXITNOW
	) ELSE (
		COPY /Y %EMPPATH%\useraudit_AFTER.txt %EMPPATH%\useraudit%YYYY%%MM%%DD%_AFTER.txt
	)
	

:CLEANUP
	DEL /Q /F %EMPPATH%\useraudit_BEFORE.txt
	DEL /Q /F %EMPPATH%\useraudit_AFTER.txt

:EXITNOW
	exit /B %ERRORLEVEL%

