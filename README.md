# Hexagonal .Net 3.1

# Iniciar os segredos de usuários
- dotnet user-secrets init --project .\WebApi.csproj 

# Configurar a string de conexão ao banco de dados
- dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=Demo;User=sa;Password=***;MultipleActiveResultSets=true"
- dotnet user-secrets list --project .\WebApi.csproj

# Deletar um segredo de usuário da aplicação.
- dotnet user-secrets remove "[CHAVE]"

# Banco
- cd Infra.Data
- Add-Migration InitialCreate
- Update-Database

# Estrutura
- .NET Core 3.1: Framework para desenvolvimento da Microsoft.
- Arquitetura Hexagonal.
- Entity FrameWork
