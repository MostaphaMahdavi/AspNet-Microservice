#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Discount/Discount.Grpc/Discount.Grpc.csproj", "Services/Discount/Discount.Grpc/"]
COPY ["Services/Discount/Discount.Services/Discount.Services.csproj", "Services/Discount/Discount.Services/"]
COPY ["Services/Discount/Discount.Repositories/Discount.Repositories.csproj", "Services/Discount/Discount.Repositories/"]
COPY ["Services/Discount/Discount.DataAccessLayers/Discount.DataAccessLayers.csproj", "Services/Discount/Discount.DataAccessLayers/"]
COPY ["Services/Discount/Discount.Domains/Discount.Domains.csproj", "Services/Discount/Discount.Domains/"]
COPY ["Services/Frameworks/aspnetrun-microservice.Frameworks/aspnetrun-microservice.Frameworks.csproj", "Services/Frameworks/aspnetrun-microservice.Frameworks/"]
RUN dotnet restore "Services/Discount/Discount.Grpc/Discount.Grpc.csproj"
COPY . .
WORKDIR "/src/Services/Discount/Discount.Grpc"
RUN dotnet build "Discount.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discount.Grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discount.Grpc.dll"]
