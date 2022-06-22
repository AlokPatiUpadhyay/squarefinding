
# Use Microsoft's official build .NET image.
# https://hub.docker.com/_/microsoft-dotnet-core-sdk/
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

# Install production dependencies.
# Copy csproj and restore as distinct layers.
COPY *.sln .
COPY SquareFindings/*.csproj ./SquareFindings/
COPY SquareFindings.UnitTestCoverage/*.csproj ./SquareFindings.UnitTestCoverage/
RUN dotnet restore


# Copy local code to the container image.
COPY SquareFindings/. ./SquareFindings/
COPY SquareFindings.UnitTestCoverage/. ./SquareFindings.UnitTestCoverage/

WORKDIR /app/SquareFindings

# Build a release artifact.
RUN dotnet publish -c Release -o out

# Use Microsoft's official runtime .NET image.
# https://hub.docker.com/_/microsoft-dotnet-core-aspnet/
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/SquareFindings/out ./


# Run the web service on container startup.
ENTRYPOINT ["dotnet", "SquareFindings.dll"]
