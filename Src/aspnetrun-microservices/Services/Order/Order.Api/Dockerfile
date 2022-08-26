#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Order/Order.Api/Order.Api.csproj", "Services/Order/Order.Api/"]
COPY ["Services/Order/Order.Services/Order.Services.csproj", "Services/Order/Order.Services/"]
COPY ["Services/Order/Order.Repositories/Order.Repositories.csproj", "Services/Order/Order.Repositories/"]
COPY ["Services/Order/Order.DataAccessLayers/Order.DataAccessLayers.csproj", "Services/Order/Order.DataAccessLayers/"]
COPY ["Services/Order/Order.Domains/Order.Domains.csproj", "Services/Order/Order.Domains/"]
COPY ["Services/Frameworks/aspnetrun-microservice.Frameworks/aspnetrun-microservice.Frameworks.csproj", "Services/Frameworks/aspnetrun-microservice.Frameworks/"]
RUN dotnet restore "Services/Order/Order.Api/Order.Api.csproj"
COPY . .
WORKDIR "/src/Services/Order/Order.Api"
RUN dotnet build "Order.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Order.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.Api.dll"]
