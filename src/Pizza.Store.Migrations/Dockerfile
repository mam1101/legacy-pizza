FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Pizza.Store.Migrations/Pizza.Store.Migrations.csproj", "src/Pizza.Store.Migrations/"]
RUN dotnet restore "src/Pizza.Store.Migrations/Pizza.Store.Migrations.csproj"
COPY . .
WORKDIR "/src/src/Pizza.Store.Migrations"
RUN dotnet build "Pizza.Store.Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pizza.Store.Migrations.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pizza.Store.Migrations.dll"]
