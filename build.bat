ECHO OFF

if "%1" == "" goto paramError 
if "%1" == "release" goto Build
goto paramError

:Build
echo ------------------------------
echo Building Release

rem rmdir /S /Q Deploy
rmdir /S /Q bin\Release

mkdir bin\Release

c:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe n.random.generator.sln /p:Configuration=Release

echo Exit Code is %errorlevel%
if %errorlevel% GTR 0 goto error
goto done

:paramError
echo ------------------------------
echo Please specify "< release >"
goto done

:error
echo ------------------------------
echo Error in bulid
Exit /B %ERRORLEVEL%

:done
echo ------------------------------
For /f "tokens=2-4 delims=/ " %%a in ('date /t') do (set mydate=%%c-%%a-%%b)
For /f "tokens=1-2 delims=/:" %%a in ('time /t') do (set mytime=%%a%%b)

echo COMPLETE - %1 - %2 - %mydate% %mytime%