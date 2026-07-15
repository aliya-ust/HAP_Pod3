@echo off
setlocal

echo Stopping Elasticsearch and Kibana...

REM Find and kill Elasticsearch processes
for /f "tokens=2 delims=," %%i in ('tasklist /fi "imagename eq java.exe" /fo csv /nh 2^>nul') do (
    taskkill /f /pid %%i 2>nul
)

REM Fallback: kill by window title
taskkill /f /fi "WINDOWTITLE eq Elasticsearch" 2>nul
taskkill /f /fi "WINDOWTITLE eq Kibana" 2>nul

echo Done.
