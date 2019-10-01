### Criar solucao vazia
dotnet new sln - n "MinhaApiCompleta"

### Adicionar projetos na soluçào
dotnet sln add src/DevIO.Business/DevIO.Business.csproj
dotnet sln add src/DevIO.Data/DevIO.Data.csproj

### Adicionar projeto webaplication
dotnet new webapi -n "DevIO.Api"

### Listar Projetos de uma solucao
dotnet sln MinhaApiCompleta.sln list

### Adicionar referencia entre projetos
dotnet add reference ../DevIO.Business/DevIO.Business.csproj
dotnet add reference ../DevIO.Data/DevIO.Data.csproj

### Listar as referencias do projeto
dotnet list reference

### Rodas as migrations
dotnet ef database update -s ../DevIO.Api/

### Docker 
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=master.2019' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu

