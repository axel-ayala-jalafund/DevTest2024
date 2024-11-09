FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ApiBackend.API/ApiBackend.API.csproj", "ApiBackend.API/"]
COPY ["ApiBackend.Core/ApiBackend.Core.csproj", "ApiBackend.Core/"]
COPY ["ApiBackend.Infraestructure/ApiBackend.Infraestructure.csproj", "ApiBackend.Infraestructure/"]
RUN dotnet restore "ApiBackend.API/ApiBackend.API.csproj"
COPY . .
WORKDIR "/src/ApiBackend.API"
RUN dotnet build "ApiBackend.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiBackend.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiBackend.API.dll"]

