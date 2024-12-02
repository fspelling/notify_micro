FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["projects/Poc.NotifySend/Poc.NotifySendEmail.Worker/Poc.NotifySendEmail.Worker.csproj", "Poc.NotifySend/Poc.NotifySendEmail.Worker/"]
COPY ["projects/Poc.NotifySend/Poc.NotifySend.Service/Poc.NotifySend.Service.csproj", "Poc.NotifySend/Poc.NotifySend.Service/"]
COPY ["projects/Poc.NotifySend/Poc.NotifySend.Domain/Poc.NotifySend.Domain.csproj", "Poc.NotifySend/Poc.NotifySend.Domain/"]
RUN dotnet restore "Poc.NotifySend/Poc.NotifySendEmail.Worker/Poc.NotifySendEmail.Worker.csproj"
COPY . .
WORKDIR "/src/projects/Poc.NotifySend/Poc.NotifySendEmail.Worker"
RUN dotnet build "Poc.NotifySendEmail.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Poc.NotifySendEmail.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Poc.NotifySendEmail.Worker.dll"]