# Use the full .NET SDK for the single-stage build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project files (both TestRender and TestRender.Core)
COPY ["PatientManagement.Api/PatientManagement.Api.csproj", "PatientManagement.Api/"]
COPY ["PatientManagement.Application/PatientManagement.Application.csproj", "PatientManagement.Application/"]
COPY ["PatientManagement.Core/PatientManagement.Core.csproj", "PatientManagement.Core/"]
COPY ["PatientManagement.Infrastructure/PatientManagement.Infrastructure.csproj", "PatientManagement.Infrastructure/"]

# Restore dependencies
RUN dotnet restore "PatientManagement.Api/PatientManagement.Api.csproj"

# Copy all the source files for TestRender and TestRender.Core
COPY . .

# Build the project in Release mode
RUN dotnet build "PatientManagement.Api/PatientManagement.Api.csproj" -c Release -o /app/build

# Publish the app
RUN dotnet publish "PatientManagement.Api/PatientManagement.Api.csproj" -c Release -o /app/publish

# Use ASP.NET runtime for the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose ports and set the entry point
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "PatientManagement.Api.dll"]
