FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebApiWithRedis/WebApiWithRedis.csproj", "WebApiWithRedis/"]
RUN dotnet restore "WebApiWithRedis/WebApiWithRedis.csproj"
COPY . .
WORKDIR "/src/WebApiWithRedis"
RUN dotnet build "WebApiWithRedis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiWithRedis.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiWithRedis.dll"]
