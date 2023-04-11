# Define la imagen base
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Establece el directorio de trabajo en el contenedor
WORKDIR /app

# Copia el archivo csproj para restaurar las dependencias
COPY *.csproj ./

# Restaura las dependencias
RUN dotnet restore

# Copia todo el c�digo fuente al contenedor
COPY . ./

# Genera el artefacto de compilaci�n
RUN dotnet publish -c Release -o out

# Define la imagen final
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Establece el directorio de trabajo en el contenedor
WORKDIR /app

# Copia el artefacto generado en la fase de compilaci�n al contenedor
COPY --from=build /app/out ./

# Expone los puertos de la aplicaci�n
EXPOSE 80
EXPOSE 443

# Establece el punto de entrada para la aplicaci�n
ENTRYPOINT ["dotnet", "flotilla.dll"]