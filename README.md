### Tecnologias ultilizadas
-.net core 2.2
-Entity Framework
-Sqlite
-Bootstrap/FontAwesome
-AutoMapper

# Como executar
Executar os seguintes comandos:
dotnet ef migrations add InitialCreate -p .\Dados -s .\Fornecedores
dotnet ef database update -p .\Dados -s .\Fornecedores


No application.properties foi deixado o dll como update para criação da tabela. Vale ressaltar que para uma aplicação em produção isso não deve ser usado, normalmente qualquer coisa feita no banco é na mão, ou com migrations como Flyway. Aqui para este desafio mantive desta forma para facilitar os testes.


## O que poderia ter sido feito a mais:

- Docker compose para subir tudo de forma automática.
- Melhorar o layout e organizar melhor os códigos JS e CSS.
- Testes Unitários.
- Melhorar o feedback pro usuário e load entre carregamentos.
