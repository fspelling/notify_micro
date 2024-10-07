FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5235

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["projects/Poc.NotifyPublish/Poc.NotifyPublish.API/Poc.NotifyPublish.API.csproj", "Poc.NotifyPublish/Poc.NotifyPublish.API/"]
COPY ["projects/Poc.NotifyPublish/Poc.NotifyPublish.Service/Poc.NotifyPublish.Service.csproj", "Poc.NotifyPublish/Poc.NotifyPublish.Service/"]
COPY ["projects/Poc.NotifyPublish/Poc.NotifyPublish.Domain/Poc.NotifyPublish.Domain.csproj", "Poc.NotifyPublish/Poc.NotifyPublish.Domain/"]
RUN dotnet restore "Poc.NotifyPublish/Poc.NotifyPublish.API/Poc.NotifyPublish.API.csproj"
COPY . .
WORKDIR "/src/projects/Poc.NotifyPublish/Poc.NotifyPublish.API"
RUN dotnet build "Poc.NotifyPublish.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Poc.NotifyPublish.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Poc.NotifyPublish.API.dll"]