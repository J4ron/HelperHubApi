# Multistage Build by Skpetic Systems
# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY RenderApi/RenderApi.csproj ./RenderApi/
WORKDIR /app/RenderApi
RUN dotnet restore
COPY RenderApi/. ./
RUN dotnet publish -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5010
ENTRYPOINT ["dotnet", "RenderApi.dll"]