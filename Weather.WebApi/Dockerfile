# Build and Publish
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
COPY . ./src
WORKDIR "/src/Weather.WebApi"
RUN dotnet publish --os linux -c Release -o /app/publish /p:UseAppHost=false

# Host
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "Weather.WebApi.dll"]
