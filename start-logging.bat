@echo off
setlocal

echo =========================================
echo  HealthCare - Logging Stack Startup
echo =========================================
echo.
echo Step 1: Starting Elasticsearch...
call start-elasticsearch.bat

echo Waiting 15 seconds for Elasticsearch to initialize...
ping -n 16 127.0.0.1 > nul

echo.
echo Step 2: Starting Kibana...
call start-kibana.bat

echo.
echo =========================================
echo  Logging stack is starting up.
echo  Elasticsearch: http://localhost:9200
echo  Kibana:        http://localhost:5601
echo =========================================
echo.
echo NOTE: Run your API project after ES is ready:
echo   dotnet run --project HealthCare.Api
echo.
