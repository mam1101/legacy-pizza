FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Pizza.Store.API/Pizza.Store.API.csproj", "src/Pizza.Store.API/"]
COPY ["src/Pizza.Store.Core/Pizza.Store.Core.csproj", "src/Pizza.Store.Core/"]
RUN dotnet restore "src/Pizza.Store.API/Pizza.Store.API.csproj"
COPY . .
WORKDIR "/src/src/Pizza.Store.API"
RUN dotnet build "Pizza.Store.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pizza.Store.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pizza.Store.API.dll"]
