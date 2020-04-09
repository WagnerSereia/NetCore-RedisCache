FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 44336

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["NetCoreCache.UI/NetCoreCache.UI.csproj", "NetCoreCache.UI/"]
RUN dotnet restore "NetCoreCache.UI/NetCoreCache.UI.csproj"
COPY . .
WORKDIR "/src/src/NetCoreCache.UI"
RUN dotnet build "NetCoreCache.UI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NetCoreCache.UI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS http://*:44336
ENV ASPNETCORE_ENVIRONMENT Development
EXPOSE 44336
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetCoreCache.UI.dll"]