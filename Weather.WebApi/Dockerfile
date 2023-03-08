# Build and Publish
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS publish
COPY . ./src
WORKDIR "/src/Weather.WebApi"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Host
FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "Weather.WebApi.dll"]
