@echo off
setlocal

set KIBANA_HOME=%~dp0tools\kibana\kibana-9.4.3

echo Starting Kibana...
echo Config: %KIBANA_HOME%\config\kibana.yml

start "Kibana" /MIN "%KIBANA_HOME%\bin\kibana.bat"

echo.
echo Kibana starting on http://localhost:5601
echo It may take ~30 seconds to be ready.
echo.
