# NexBank

Projeto de uma conta virtual utilizando .Net Core e AngularJS.

# Back-End
No BackEnd foram utilizados os conceitos/padrões de:
  - CQRS
  - UnitOfWork

O banco de dados na v1 esta InMemory.

Rodando os testes:
```sh
dotnet test
```

Para rodar a aplicação:
```sh
cd NexBank.Api/
dotnet run
```

A API estará rodando no endpoint
```sh
https://localhost:5001/v1/
```

A API esta documentada com swagger na rota:
```sh
https://localhost:5001/swagger/index.html
```

# Front-End

Para rodar o front end recomendo utilizar o pacote [http-server](https://www.npmjs.com/package/http-server)
Necessário a instalação do [Node.js](https://nodejs.org/)

Após isso, basta:
```sh
cd NexBank.FrontEnd/
npx http-server -o
```

A tela list-accounts é apenas para propostas de DEMO, para facilitar a troca entre contas.

### Todos

 - Transformar as requisições da API em async
 - Adicionar tratamento de exceções
 - Autenticações