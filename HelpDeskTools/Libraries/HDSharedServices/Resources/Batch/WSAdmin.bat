@ECHO OFF

net localgroup administrators wwwint\wsadmin /delete

net localgroup administrators wwwint\wsadminsretail /add

ping -n 6 127.0.0.1 > NUL