#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LogSystem.WebApps.API/LogSystem.WebApps.API.csproj", "LogSystem.WebApps.API/"]
COPY ["LogSystem.Application/LogSystem.Application.csproj", "LogSystem.Application/"]
COPY ["LogSystem.Domain/LogSystem.Domain.csproj", "LogSystem.Domain/"]
COPY ["LogSystem.Infrastructure/LogSystem.Infrastructure.csproj", "LogSystem.Infrastructure/"]
RUN dotnet restore "LogSystem.WebApps.API/LogSystem.WebApps.API.csproj"
COPY . .
WORKDIR "/src/LogSystem.WebApps.API"
RUN dotnet build "LogSystem.WebApps.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LogSystem.WebApps.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogSystem.WebApps.API.dll"]