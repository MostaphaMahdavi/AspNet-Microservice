#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Basket/Basket.Api/Basket.Api.csproj", "Services/Basket/Basket.Api/"]
COPY ["Services/Basket/Basket.Services/Basket.Services.csproj", "Services/Basket/Basket.Services/"]
COPY ["Services/Basket/Basket.Repositories/Basket.Repositories.csproj", "Services/Basket/Basket.Repositories/"]
COPY ["Services/Basket/Basket.DataAccessLayers/Basket.DataAccessLayers.csproj", "Services/Basket/Basket.DataAccessLayers/"]
COPY ["Services/Basket/Basket.Domain/Basket.Domain.csproj", "Services/Basket/Basket.Domain/"]
COPY ["Services/Frameworks/aspnetrun-microservice.Frameworks/aspnetrun-microservice.Frameworks.csproj", "Services/Frameworks/aspnetrun-microservice.Frameworks/"]
RUN dotnet restore "Services/Basket/Basket.Api/Basket.Api.csproj"
COPY . .
WORKDIR "/src/Services/Basket/Basket.Api"
RUN dotnet build "Basket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basket.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basket.Api.dll"]
