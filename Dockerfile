# Imagen base para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app

# Puerto del contenedor
EXPOSE 8080

# ASP.NET escuchará en el puerto 8080
ENV ASPNETCORE_URLS=http://+:8080

# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar archivo del proyecto
COPY ["FarmaciaDevOps/FarmaciaDevOps.csproj", "FarmaciaDevOps/"]

# Restaurar dependencias
RUN dotnet restore "FarmaciaDevOps/FarmaciaDevOps.csproj"

# Copiar todo el proyecto
COPY . .

# Compilar proyecto
WORKDIR "/src/FarmaciaDevOps"
RUN dotnet build "FarmaciaDevOps.csproj" -c Release -o /app/build

# Publicar aplicación
FROM build AS publish
WORKDIR "/src/FarmaciaDevOps"
RUN dotnet publish "FarmaciaDevOps.csproj" -c Release -o /app/publish

# Imagen final
FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "FarmaciaDevOps.dll"]
