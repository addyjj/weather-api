# Build and Publish
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS publish
COPY . ./src
WORKDIR "/src/Weather.Console"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Host
FROM mcr.microsoft.com/dotnet/runtime:7.0
RUN apt-get update && apt-get -y install cron
WORKDIR /app
COPY --from=publish /app/publish .

# Adding crontab to the appropriate location
RUN echo "*/15 * * * * dotnet /app/import.dll" >> /etc/cron.d/weather-cron

# Create folders
RUN mkdir -p /app/logs 

# Set permissions
RUN chmod 644 /etc/cron.d/weather-cron
RUN chmod 666 /app/logs

# Running crontab
RUN crontab /etc/cron.d/weather-cron

VOLUME /app/logs

ENTRYPOINT ["cron", "-f"]