FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080

COPY publish/api .
COPY HealthCare.Portal/dist/HealthCare.Portal/browser /app/wwwroot
COPY publish/admin/wwwroot /app/wwwroot/admin

ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "HealthCare.Api.dll"]