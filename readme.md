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

