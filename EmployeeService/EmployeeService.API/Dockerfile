# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only .csproj files
COPY ./EmployeeService/EmployeeService.API/EmployeeService.API.csproj ./EmployeeService.API/
COPY ./EmployeeService/EmployeeService.Application/EmployeeService.Application.csproj ./EmployeeService.Application/
COPY ./EmployeeService/EmployeeService.Domain/EmployeeService.Domain.csproj ./EmployeeService.Domain/
COPY ./EmployeeService/EmployeeService.Infrastructure/EmployeeService.Infrastructure.csproj ./EmployeeService.Infrastructure/

# Restore
RUN dotnet restore ./EmployeeService.API/EmployeeService.API.csproj

# Copy all source files
COPY ./EmployeeService/EmployeeService.API ./EmployeeService.API/
COPY ./EmployeeService/EmployeeService.Application ./EmployeeService.Application/
COPY ./EmployeeService/EmployeeService.Domain ./EmployeeService.Domain/
COPY ./EmployeeService/EmployeeService.Infrastructure ./EmployeeService.Infrastructure/

# Publish
WORKDIR /src/EmployeeService.API
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EmployeeService.API.dll"]
