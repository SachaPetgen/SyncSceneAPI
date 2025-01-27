# Consultez https://aka.ms/customizecontainer pour savoir comment personnaliser votre conteneur de débogage et comment Visual Studio utilise ce Dockerfile pour générer vos images afin d’accélérer le débogage.

# Cet index est utilisé lors de l’exécution à partir de VS en mode rapide (par défaut pour la configuration de débogage)
FROM mcr.microsoft.com/dotnet/aspnet:9.0-bookworm-slim AS base
USER $APP_UID
WORKDIR /app

# Cette phase est utilisée pour générer le projet de service
FROM mcr.microsoft.com/dotnet/sdk:9.0-bookworm-slim AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SyncScene.API/SyncScene.API.csproj", "SyncScene.API/"]
COPY ["SyncScene.Application/SyncScene.Application.csproj", "SyncScene.Application/"]
COPY ["SyncScene.Domain/SyncScene.Domain.csproj", "SyncScene.Domain/"]
COPY ["SyncScene.Infrastructure.DB/SyncScene.Infrastructure.DB.csproj", "SyncScene.Infrastructure.DB/"]
RUN dotnet restore "./SyncScene.API/SyncScene.API.csproj"

COPY . /src

WORKDIR "/src/SyncScene.API"
RUN dotnet build "./SyncScene.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Cette étape permet de publier le projet de service à copier dans la phase finale
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SyncScene.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Cette phase est utilisée en production ou lors de l’exécution à partir de VS en mode normal (par défaut quand la configuration de débogage n’est pas utilisée)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SyncScene.API.dll"]