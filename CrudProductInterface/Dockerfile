FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CrudProductInterface/CrudProductInterface.csproj", "CrudProductInterface/"]
COPY ["CrudProduct/CrudProduct.csproj", "CrudProduct/"]
RUN dotnet restore "CrudProductInterface/CrudProductInterface.csproj"
COPY CrudProductInterface/. CrudProductInterface/
COPY CrudProduct/. CrudProduct/
WORKDIR "/src/CrudProductInterface"
RUN dotnet build "CrudProductInterface.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR /src/CrudProductInterface
RUN rm -f /src/CrudProduct/appsettings.json /src/CrudProduct/appsettings.Development.json
RUN dotnet publish "CrudProductInterface.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CrudProductInterface.dll"]
