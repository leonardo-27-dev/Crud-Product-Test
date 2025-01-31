FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CrudProduct/CrudProduct.csproj", "CrudProduct/"]
RUN dotnet restore "CrudProduct/CrudProduct.csproj"
COPY CrudProduct/. CrudProduct/
WORKDIR "/src/CrudProduct"
RUN dotnet build "CrudProduct.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CrudProduct.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CrudProduct.dll"]
