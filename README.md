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


## [Project Setup](SETUP.md)

For the project setup step by step, please, go to the [SETUP.md](SETUP.md) file.

## [API Documentation](API.md)

For the API documentation, please, go to the [API.md](API.md) file.

## Project description

* :white_check_mark: Tela (via um formulário) para fazer o upload do arquivo
* :white_check_mark: Interpretar ("parsear") do arquivo recebido, normalização dos dados, e salvar corretamente a informação em um banco de dados relacional
* :white_check_mark: Exibir uma lista das operações importadas por lojas, e nesta lista deve conter um totalizador do saldo em conta
* :white_check_mark: Escrito em C# .NET 6
* :white_check_mark: Simples de configurar e rodar, funciona em ambiente compatível com Unix (Linux ou Mac OS X). Utiliza apenas linguagens e bibliotecas livres ou gratuitas.
* :white_check_mark: Git com commits atomicos e bem descritos
* :white_check_mark: SQL Server
* :white_check_mark: Testes automatizados
* :black_square_button: Docker compose (Pendente)
* :white_check_mark: Readme file descrevendo bem o projeto e seu setup
* :white_check_mark: Informação descrevendo como consumir o endpoint da API
* :eight_pointed_black_star: **Extra:** Faz autenticação ou autorização (JWT com Refresh Token)
* :eight_pointed_black_star: **Extra:** Documentação da API (Markdown e Swagger)

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
