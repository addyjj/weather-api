#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS publish
COPY . ./src
WORKDIR "/src/Weather.Console"

# Build and Publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
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