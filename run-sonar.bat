@echo off

REM ✅ SET VARIABLES
SET SONAR_TOKEN=sqp_cb4830471d44f8c9ce100e60cc02a3e6174ad8f2
SET SONAR_URL=http://localhost:9000
SET PROJECT_KEY=healthcare
SET SOLUTION=HealthCare.sln

REM ✅ STEP 1 - START SONAR
echo Starting SonarQube analysis...
SonarScanner.MSBuild.exe begin ^
/k:"%PROJECT_KEY%" ^
/d:sonar.host.url="%SONAR_URL%" ^
/d:sonar.login="%SONAR_TOKEN%" ^
/d:sonar.cs.opencover.reportsPaths="coverage.opencover.xml"

IF %ERRORLEVEL% NEQ 0 (
    echo Sonar begin failed
    exit /b %ERRORLEVEL%
)

REM ✅ STEP 2 - BUILD SOLUTION
echo Building solution...
MSBuild.exe "%SOLUTION%" /t:Rebuild /p:Configuration=Debug

IF %ERRORLEVEL% NEQ 0 (
    echo Build failed
    exit /b %ERRORLEVEL%
)

REM ✅ STEP 3 - RUN TESTS WITH COVERAGE (OpenCover)
echo Running tests with coverage...

OpenCover.Console.exe ^
-target:"vstest.console.exe" ^
-targetargs:"HealthCare.Api.Tests\bin\Debug\HealthCare.Api.Tests.dll HealthCare.Web.Tests\bin\Debug\HealthCare.Web.Tests.dll" ^
-output:"coverage.opencover.xml" ^
-register:user

IF %ERRORLEVEL% NEQ 0 (
    echo Tests or coverage failed
    exit /b %ERRORLEVEL%
)

REM ✅ STEP 4 - END SONAR
echo Finishing SonarQube analysis...
SonarScanner.MSBuild.exe end ^
/d:sonar.login="%SONAR_TOKEN%"

IF %ERRORLEVEL% NEQ 0 (
    echo Sonar end failed
    exit /b %ERRORLEVEL%
)

echo ✅ SonarQube scan completed successfully!
pause