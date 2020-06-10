### Tecnologias ultilizadas
- net core 2.2
- Entity Framework
- Sqlite
- Bootstrap/FontAwesome
- AutoMapper

# Como executar
Executar os seguintes comandos:
- dotnet ef migrations add InitialCreate -p .\Dados -s .\Fornecedores
- dotnet ef database update -p .\Dados -s .\Fornecedores

## O que poderia ter sido feito a mais:

- Docker compose para subir tudo de forma automática.
- Melhorar o layout e organizar melhor os códigos JS e CSS.
- Testes Unitários.
- Melhorar o feedback pro usuário e load entre carregamentos.
