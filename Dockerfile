# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar arquivos de projeto e restaurar dependências
COPY CrudProduct/*.csproj CrudProduct/
COPY CrudProductInterface/*.csproj CrudProductInterface/
RUN dotnet nuget locals all --clear
RUN dotnet restore CrudProduct/CrudProduct.csproj
RUN dotnet restore CrudProductInterface/CrudProductInterface.csproj

# Copiar todo o código-fonte
COPY . .

# Compilar e publicar a API
WORKDIR /src/CrudProduct
RUN dotnet publish -c Release --no-restore -o /app/api_publish

# Compilar e publicar a Interface
WORKDIR /src/CrudProductInterface
RUN dotnet publish -c Release --no-restore -o /app/interface_publish

# Etapa final para API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime-api
WORKDIR /app/api
COPY --from=build /app/api_publish .
EXPOSE 80

# Executar migrations antes de iniciar a API
ENTRYPOINT ["sh", "-c", "dotnet CrudProduct.dll & dotnet ef database update"]

# Etapa final para Interface
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime-interface
WORKDIR /app/interface
COPY --from=build /app/interface_publish .
EXPOSE 81
ENTRYPOINT ["dotnet", "CrudProductInterface.dll"]