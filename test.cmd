@ECHO OFF

ECHO Running c# tests
dotnet test
IF %errorlevel% NEQ 0 EXIT /B %errorlevel%

EXIT /B %ERRORLEVEL%
