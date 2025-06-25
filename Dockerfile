# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base runtime image for .NET 9
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# SDK image for building the project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files
COPY ["Sandbox.Data/Sandbox.Data.csproj", "src/Sandbox.Data/"]
COPY ["Sandbox.Domain/Sandbox.Domain.csproj", "src/Sandbox.Domain/"]
COPY ["Sandbox.Migrations/Sandbox.Migrations.csproj", "src/Sandbox.Migrations/"]
COPY ["Sandbox.Services/Sandbox.Services.csproj", "src/Sandbox.Services/"]
COPY ["Sandbox.Web/Sandbox.Web.csproj", "src/Sandbox.Web/"]

# Restore dependencies
RUN dotnet restore "src/Sandbox.Web/Sandbox.Web.csproj"

# Copy full source
COPY . .

# Build the app
WORKDIR "/src/Sandbox.Web"
RUN dotnet build "Sandbox.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the app
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Sandbox.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Optional: set environment variable for production config
# ENV ASPNETCORE_ENVIRONMENT=Production

# Remove config files that will be mounted from host
RUN rm -f appsettings*.json

ENTRYPOINT ["dotnet", "Sandbox.Web.dll"]
