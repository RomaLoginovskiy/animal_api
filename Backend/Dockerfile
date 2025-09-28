# Use the official .NET 9.0 runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the .NET 9.0 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["camunda_challenge.csproj", "."]
RUN dotnet restore "./camunda_challenge.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "camunda_challenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "camunda_challenge.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Create media directory for file storage
RUN mkdir -p /app/media/dev

ENTRYPOINT ["dotnet", "camunda_challenge.dll"]
