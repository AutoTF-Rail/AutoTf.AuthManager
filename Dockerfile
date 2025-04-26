FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 81

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
RUN apt-get update && apt-get install -y python3
RUN dotnet workload install wasm-tools

ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AutoTf.AuthManager/AutoTf.AuthManager.csproj", "AutoTf.AuthManager/"]
RUN dotnet restore "AutoTf.AuthManager/AutoTf.AuthManager.csproj"
COPY . .

WORKDIR "/src/AutoTf.AuthManager"
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AutoTf.AuthManager.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoTf.AuthManager.dll"]
