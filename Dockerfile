# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY app/ .
RUN dotnet publish -c Release -o /out

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /out .

ENV ASPNETCORE_URLS=http://+:8083

ENTRYPOINT ["dotnet", "app.dll"]
