@echo off
setlocal

set ES_HOME=%~dp0tools\elasticsearch\elasticsearch-9.4.3

echo Starting Elasticsearch (health-care)...
echo Data dir: %ES_HOME%\data
echo Logs:     %ES_HOME%\logs

start "Elasticsearch" /MIN "%ES_HOME%\bin\elasticsearch.bat"

echo.
echo Elasticsearch starting on http://localhost:9200
echo Wait ~30 seconds for it to be ready, then start Kibana.
echo.
echo To verify: curl http://localhost:9200
echo.
