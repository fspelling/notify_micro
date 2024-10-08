FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["projects/Poc.NotifyOrchestrator/Poc.NotifyOrchestrator.Worker/Poc.NotifyOrchestrator.Worker.csproj", "Poc.NotifyOrchestrator/Poc.NotifyOrchestrator.Worker/"]
COPY ["projects/Poc.NotifyOrchestrator/Poc.NotifyOrchestrator.Service/Poc.NotifyOrchestrator.Service.csproj", "Poc.NotifyOrchestrator/Poc.NotifyOrchestrator.Service/"]
COPY ["projects/Poc.NotifyOrchestrator/Poc.NotifyOrchestrator.EntityFramework/Poc.NotifyOrchestrator.EntityFramework.csproj", "Poc.NotifyOrchestrator/Poc.NotifyOrchestrator.EntityFramework/"]
COPY ["projects/Poc.NotifyOrchestrator/Poc.NotifyOrchestrator.Cache/Poc.NotifyOrchestrator.Cache.csproj", "Poc.NotifyOrchestrator/Poc.NotifyOrchestrator.Cache/"]
COPY ["projects/Poc.NotifyOrchestrator/Poc.NotifyOrchestrator.Domain/Poc.NotifyOrchestrator.Domain.csproj", "Poc.NotifyOrchestrator/Poc.NotifyOrchestrator.Domain/"]
RUN dotnet restore "Poc.NotifyOrchestrator/Poc.NotifyOrchestrator.Worker/Poc.NotifyOrchestrator.Worker.csproj"
COPY . .
WORKDIR "/src/projects/Poc.NotifyOrchestrator/Poc.NotifyOrchestrator.Worker"
RUN dotnet build "Poc.NotifyOrchestrator.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Poc.NotifyOrchestrator.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Poc.NotifyOrchestrator.Worker.dll"]