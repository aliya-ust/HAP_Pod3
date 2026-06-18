@echo off

SET SONAR_TOKEN=sqp_94fe1cf539b125992595a1a2b4f357b0ae70a51e
SET SONAR_URL=http://localhost:9000
SET PROJECT_KEY=HealthCareSprint3

echo Starting Sonar analysis...

dotnet sonarscanner begin ^
  /k:"%PROJECT_KEY%" ^
  /d:sonar.host.url="%SONAR_URL%" ^
  /d:sonar.login="%SONAR_TOKEN%" ^
  /d:sonar.exclusions="**/bin/**,**/obj/**,**/Migrations/**"

IF %ERRORLEVEL% NEQ 0 (
  echo Sonar begin failed!
  exit /b %ERRORLEVEL%
)

echo Building project...

dotnet build

IF %ERRORLEVEL% NEQ 0 (
  echo Build failed!
  exit /b %ERRORLEVEL%
)

echo Ending Sonar analysis...

dotnet sonarscanner end ^
  /d:sonar.login="%SONAR_TOKEN%"

IF %ERRORLEVEL% NEQ 0 (
  echo Sonar end failed!
  exit /b %ERRORLEVEL%
)

echo ✅ Sonar scan completed successfully!
pause
``