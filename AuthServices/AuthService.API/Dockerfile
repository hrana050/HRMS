# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ./AuthServices/AuthService.API/AuthService.API.csproj ./AuthService.API/
COPY ./AuthServices/AuthService.Application/AuthService.Application.csproj ./AuthService.Application/
COPY ./AuthServices/AuthService.Domain/AuthService.Domain.csproj ./AuthService.Domain/
COPY ./AuthServices/AuthService.Infrastructure/AuthService.Infrastructure.csproj ./AuthService.Infrastructure/

# Restore
RUN dotnet restore ./AuthService.API/AuthService.API.csproj

# Copy all code
COPY ./AuthServices/AuthService.API ./AuthService.API
COPY ./AuthServices/AuthService.Application ./AuthService.Application
COPY ./AuthServices/AuthService.Domain ./AuthService.Domain
COPY ./AuthServices/AuthService.Infrastructure ./AuthService.Infrastructure

# Build and publish
WORKDIR /src/AuthService.API
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Correct COPY line
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "AuthService.API.dll"]
