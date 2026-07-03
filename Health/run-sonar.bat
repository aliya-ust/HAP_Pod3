@echo off

SET SONAR_TOKEN=sqp_f2519fbb1ee90f3c882b31af16f6f669ec16feac
SET SONAR_URL=http://localhost:9000
SET PROJECT_KEY=HealthCareSprint3

echo Starting Sonar analysis...

dotnet sonarscanner begin ^
  /k:"%PROJECT_KEY%" ^
  /d:sonar.host.url="%SONAR_URL%" ^
  /d:sonar.login="%SONAR_TOKEN%" ^
  /d:sonar.exclusions="**/bin/**,**/obj/**,**/Migrations/**" ^
  /d:sonar.coverage.exclusions="**/bin/**,**/obj/**,**/Migrations/**,**/Controllers/**,**/Exceptions/**,**/Data/**,**/DTOs/**,**/Mappings/**,**/Models/**,**/Properties/**,**/Repositories/**,**/HealthCare.Shared/**,**/HealthCareAdmin.Web/**,**/HealthCareUser.Web/**,**/Middlware/**,**/Program.cs" ^
  /d:sonar.cs.opencover.reportsPaths="TestResults/**/coverage.opencover.xml"

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

echo Testing project...

dotnet test --no-build --collect:"XPlat Code Coverage" --results-directory TestResults -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=opencover

echo Ending Sonar analysis...

dotnet sonarscanner end ^
  /d:sonar.login="%SONAR_TOKEN%"

IF %ERRORLEVEL% NEQ 0 (
  echo Sonar end failed!
  exit /b %ERRORLEVEL%
)

echo Sonar scan completed successfully!
pause