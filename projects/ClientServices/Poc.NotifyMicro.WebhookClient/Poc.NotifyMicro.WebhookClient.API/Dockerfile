FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5216

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["projects/ClientServices/Poc.NotifyMicro.WebhookClient/Poc.NotifyMicro.WebhookClient.API/Poc.NotifyMicro.WebhookClient.API.csproj", "Poc.NotifyMicro.WebhookClient/Poc.NotifyMicro.WebhookClient.API/"]
RUN dotnet restore "Poc.NotifyMicro.WebhookClient/Poc.NotifyMicro.WebhookClient.API/Poc.NotifyMicro.WebhookClient.API.csproj"
COPY . .
WORKDIR "/src/projects/ClientServices/Poc.NotifyMicro.WebhookClientPoc.NotifyMicro.WebhookClient.API"
RUN dotnet build "Poc.NotifyMicro.WebhookClient.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Poc.NotifyMicro.WebhookClient.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Poc.NotifyMicro.WebhookClient.API.dll"]