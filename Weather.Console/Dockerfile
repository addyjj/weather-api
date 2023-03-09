# Build and Publish
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS publish
COPY . ./src
WORKDIR "/src/Weather.Console"
RUN dotnet publish --os linux -c Release -o /app/publish /p:UseAppHost=false

# Host
FROM mcr.microsoft.com/dotnet/runtime:7.0
RUN apt-get update && apt-get -y install cron
WORKDIR /app
COPY --from=publish /app/publish .

# Adding crontab to the appropriate location
RUN echo "*/15 * * * * dotnet /app/import.dll > /proc/1/fd/1 2>/proc/1/fd/2" >> /etc/crontab

VOLUME /logs

ENTRYPOINT ["cron", "-f"]