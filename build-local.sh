#!/bin/bash
set -e

echo "=== Pre-building for Elastic Beanstalk ==="

echo "[1/5] Restoring NuGet packages..."
dotnet restore HealthCare.Api/HealthCare.Api.csproj
dotnet restore HealthCare.Admin/HealthCare.Admin.csproj

echo "[2/5] Publishing API..."
dotnet publish HealthCare.Api/HealthCare.Api.csproj -c Release -o publish/api --no-restore

echo "[3/5] Publishing Blazor Admin..."
dotnet publish HealthCare.Admin/HealthCare.Admin.csproj -c Release -o publish/admin --no-restore

echo "[4/5] Updating Blazor base href to /admin/..."
sed -i 's|<base href="/" />|<base href="/admin/" />|g' publish/admin/wwwroot/index.html

echo "[5/5] Building Angular..."
cd HealthCare.Portal
npm ci
npx ng build --configuration production
cd ..

echo "=== Done! Now create the zip and upload to EB ==="
