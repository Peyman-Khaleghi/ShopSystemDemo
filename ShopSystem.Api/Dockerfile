FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ShopSystem.Domain/ShopSystem.Domain.csproj ./ShopSystem.Domain/
COPY ShopSystem.infrastructure/ShopSystem.infrastructure.csproj ./ShopSystem.infrastructure/
COPY ShopSystem.Api/ShopSystem.Api.csproj ./ShopSystem.Api/

RUN dotnet restore ./ShopSystem.Api/ShopSystem.Api.csproj

COPY ShopSystem.Domain ./ShopSystem.Domain
COPY ShopSystem.infrastructure ./ShopSystem.infrastructure
COPY ShopSystem.Api ./ShopSystem.Api

RUN dotnet publish ./ShopSystem.Api/ShopSystem.Api.csproj -c Release -o /publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "ShopSystem.Api.dll"]
