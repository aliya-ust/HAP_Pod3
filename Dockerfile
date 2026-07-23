FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore HealthCare.Api/HealthCare.Api.csproj
RUN dotnet publish HealthCare.Api/HealthCare.Api.csproj -c Release -o /app/api/publish --no-restore

RUN dotnet restore HealthCare.Admin/HealthCare.Admin.csproj
RUN dotnet publish HealthCare.Admin/HealthCare.Admin.csproj -c Release -o /app/admin/publish --no-restore
RUN sed -i 's|<base href="/" />|<base href="/admin/" />|g' /app/admin/publish/wwwroot/index.html

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 80

COPY --from=build /app/api/publish .
COPY HealthCare.Portal/dist/HealthCare.Portal/browser /app/wwwroot
COPY --from=build /app/admin/publish/wwwroot /app/wwwroot/admin

ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "HealthCare.Api.dll"]
