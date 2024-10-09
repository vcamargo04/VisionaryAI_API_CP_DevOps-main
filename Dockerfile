# Usando a imagem do SDK do .NET 8.0 como ambiente de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copiando todos os arquivos do projeto
COPY . ./

# Restaurando as dependências do projeto
RUN dotnet restore

# Compilando e publicando a aplicação em modo Release
RUN dotnet publish -c Release -o out

# Usando a imagem do ASP.NET 8.0 para a execução da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

# Copiando os arquivos da build para a nova imagem
COPY --from=build-env /App/out ./

# Definindo o ponto de entrada da aplicação
ENTRYPOINT ["dotnet", "VisionaryAI_API_CP_DevOps.dll"]
