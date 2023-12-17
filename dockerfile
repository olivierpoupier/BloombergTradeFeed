# Use the official .NET 8 SDK image from the dockerhub
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory in the container
WORKDIR /app

# Copy everything and build the app
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0

WORKDIR /app
COPY --from=build-env /app/out .
# Command to run the application
ENTRYPOINT ["dotnet", "TestXmlParser.dll"]
