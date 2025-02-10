# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything into the container
COPY . . 

# Restore dependencies
RUN dotnet restore

# Build and publish the application
RUN dotnet publish -c Release -o /app/out

# Use the official .NET runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app

# Copy the published application from the builder
COPY --from=build /app/out .

# Set the entry point to the application
ENTRYPOINT ["dotnet", "ArtExhibitionApp.dll"]
