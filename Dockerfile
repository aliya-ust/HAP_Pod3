FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore HealthCare.Api/HealthCare.Api.csproj
RUN dotnet publish HealthCare.Api/HealthCare.Api.csproj -c Release -o /app/api/publish --no-restore

RUN dotnet restore HealthCare.Admin/HealthCare.Admin.csproj
RUN dotnet publish HealthCare.Admin/HealthCare.Admin.csproj -c Release -o /app/admin/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS api
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/api/publish .
ENTRYPOINT ["dotnet", "HealthCare.Api.dll"]

FROM nginx:alpine AS proxy
COPY --from=build /app/admin/publish/wwwroot /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
