# ByCoders - Coding Challenge

This solution is using the following technologies:

- C# with .NET 6
- Entity Framework with SQL Server
- Swagger
- xUnit
- Angular 13 with RxJS
- SCSS
- Bootstrap and Font Awesome

Divided into the following projects:

- **Core:** C#, .NET 6, Entity Framework Core, and SQL Server<br />
Provides connection with database and repositories for common components rather than WebApi.

- **Web Api:** C#, .NET 6, WebApi, and Swagger<br />
Provides services, controllers and receives requests and send responses from/to web.

- **Front end:** Angular 13, RxJS, SCSS, Bootstrap, and FontAwesome<br />
The user front end application, send and receives data from the web api.


## Project setup

Follow this [link](docs/SETUP.md) to execute the steps to run this project in development.

**Default configuration:** *(HTTPS)*
- Back-end: https://localhost:44352/swagger
- Front-end: https://localhost:4200/

## API documentation

The API documentation is available [here](docs/API.md).

## Front-end documentation

The Front-end documentation is available [here](docs/WEB.md).

## Docker compose

Follow [these steps](DOCKER-COMPOSE.md) to run the docker-compose.

**Default configuration:** *(HTTP only)*
- Back-end: http://localhost:8081/swagger
- Front-end: http://localhost:8080/

## Project description

[Click here](docs/CHALLENGE.md) to check the original challenge readme file.

* :white_check_mark: Tela (via um formulário) para fazer o upload do arquivo
* :white_check_mark: Interpretar ("parsear") do arquivo recebido, normalização dos dados, e salvar corretamente a informação em um banco de dados relacional
* :white_check_mark: Exibir uma lista das operações importadas por lojas, e nesta lista deve conter um totalizador do saldo em conta
* :white_check_mark: Escrito em C# .NET 6
* :white_check_mark: Simples de configurar e rodar, funciona em ambiente compatível com Unix (Linux ou Mac OS X). Utiliza apenas linguagens e bibliotecas livres ou gratuitas.
* :white_check_mark: Git com commits atomicos e bem descritos
* :white_check_mark: SQL Server
* :white_check_mark: Testes automatizados
* :white_check_mark: Docker compose
* :white_check_mark: Readme file descrevendo bem o projeto e seu setup
* :white_check_mark: Informação descrevendo como consumir o endpoint da API
* :eight_pointed_black_star: **Extra:** Faz autenticação ou autorização (JWT com Refresh Token)
* :eight_pointed_black_star: **Extra:** Documentação da API (Markdown e Swagger) **+ WEB (com prints)**

## Documentação do CNAB

| Descrição do campo  | Inicio | Fim | Tamanho | Comentário
| ------------- | ------------- | -----| ---- | ------
| Tipo  | 1  | 1 | 1 | Tipo da transação
| Data  | 2  | 9 | 8 | Data da ocorrência
| Valor | 10 | 19 | 10 | Valor da movimentação. *Obs.* O valor encontrado no arquivo precisa ser divido por cem(valor / 100.00) para normalizá-lo.
| CPF | 20 | 30 | 11 | CPF do beneficiário
| Cartão | 31 | 42 | 12 | Cartão utilizado na transação 
| Hora  | 43 | 48 | 6 | Hora da ocorrência atendendo ao fuso de UTC-3
| Dono da loja | 49 | 62 | 14 | Nome do representante da loja
| Nome loja | 63 | 81 | 19 | Nome da loja

## Documentação sobre os tipos das transações

| Tipo | Descrição | Natureza | Sinal |
| ---- | -------- | --------- | ----- |
| 1 | Débito | Entrada | + |
| 2 | Boleto | Saída | - |
| 3 | Financiamento | Saída | - |
| 4 | Crédito | Entrada | + |
| 5 | Recebimento Empréstimo | Entrada | + |
| 6 | Vendas | Entrada | + |
| 7 | Recebimento TED | Entrada | + |
| 8 | Recebimento DOC | Entrada | + |
| 9 | Aluguel | Saída | - |
