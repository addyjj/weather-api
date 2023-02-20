#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Weather.Console/Weather.Console.csproj", "Weather.Console/"]
COPY ["Weather.Core/Weather.Core.csproj", "Weather.Core/"]
COPY ["Weather.Infrastructure/Weather.Infrastructure.csproj", "Weather.Infrastructure/"]
RUN dotnet restore "Weather.Console/Weather.Console.csproj"
COPY . .
WORKDIR "/src/Weather.Console"
RUN dotnet build "Weather.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Weather.Console.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
RUN apt-get update && apt-get -y install cron
WORKDIR /app
COPY --from=publish /app/publish .
RUN ls /etc/cron.d
RUN echo "*/15 * * * * dotnet /app/import.dll" >> /etc/cron.d/weather-cron
RUN chmod 0644 /etc/cron.d/weather-cron
ENTRYPOINT ["cron", "-f"]