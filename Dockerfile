# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Sandbox.Data/Sandbox.Data.csproj", "src/Sandbox.Data/"]
COPY ["Sandbox.Domain/Sandbox.Domain.csproj", "src/Sandbox.Domain/"]
COPY ["Sandbox.Migrations/Sandbox.Migrations.csproj", "src/Sandbox.Migrations/"]
COPY ["Sandbox.Services/Sandbox.Services.csproj", "src/Sandbox.Services/"]
COPY ["Sandbox.Web/Sandbox.Web.csproj", "src/Sandbox.Web/"]
RUN dotnet restore "src/Sandbox.Web/Sandbox.Web.csproj"
COPY . .
WORKDIR "/src/Sandbox.Web"
RUN dotnet build "Sandbox.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Sandbox.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sandbox.Web.dll"]