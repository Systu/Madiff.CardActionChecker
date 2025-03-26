# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Madiff.CardActionChecker.csproj", "."]
RUN dotnet restore "./Madiff.CardActionChecker.csproj"
COPY . .
RUN dotnet build "./Madiff.CardActionChecker.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Madiff.CardActionChecker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Create non-root user for security
RUN adduser --disabled-password --gecos "" appuser
USER appuser

# Copy from publish stage
COPY --from=publish /app/publish .

# Set environment variables for microservice configuration
ENV ASPNETCORE_URLS=http://+:8080
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV DOTNET_RUNNING_IN_CONTAINER=true

# Health check configuration
HEALTHCHECK --interval=30s --timeout=3s --retries=3 CMD curl --fail http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "Madiff.CardActionChecker.dll"]