#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AutoRecon.WebUI/AutoRecon.WebUI.csproj", "AutoRecon.WebUI/"]
COPY ["AutoRecon.Application/AutoRecon.Application.csproj", "AutoRecon.Application/"]
COPY ["AutoRecon.Domain/AutoRecon.Domain.csproj", "AutoRecon.Domain/"]
COPY ["AutoRecon.Infrastructure/AutoRecon.Infrastructure.csproj", "AutoRecon.Infrastructure/"]
RUN dotnet restore "./AutoRecon.WebUI/AutoRecon.WebUI.csproj"
COPY . .
WORKDIR "/src/AutoRecon.WebUI"
RUN dotnet build "./AutoRecon.WebUI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AutoRecon.WebUI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoRecon.WebUI.dll"]