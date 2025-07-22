# First stage base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copy csproj file and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy and publish application files
COPY . .
RUN dotnet publish -c release -o /app

# Final stage image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

# Start the app once the container starting
ENTRYPOINT [ "dotnet", "controlCenter.dll" ]