# Nome do Projeto

Tarefa:  Desenvolver um CRUD utilizando API REST, seguindo boas práticas de programação. O objeto do CRUD será uma lista de tarefas.​
​
Detalhes  do Projeto: O candidato é livre para adicionar propriedades, regras de negócio, escolher o banco e o que achar necessário, 
não precisa se preocupar com a parte de segurança ou infra da aplicação, apenas o necessário para rodarmos e testarmos o CRUD. 
A única regra é que não deverá ser um CRUD complexo, não iremos avaliar a dificuldade do CRUD e sim o código e suas boas práticas.​

## Instalação

Descreva aqui os passos necessários para configurar o ambiente de desenvolvimento.

1. Clone o repositório no seguinte link: "https://github.com/PedroPucci/SistemaListaAtividade.git" e o github do projeto é: https://github.com/PedroPucci/SistemaListaAtividade
2. IDE utilizada foi o Visual Studio 2022 
3. Instale as dependências com o comando `dotnet restore`
4. Foi utilizado o banco de dados Postgre

## Configuração

Explique aqui como configurar o projeto para execução local ou em ambientes específicos.

Para gerar o banco de dados no ambiente desejado, seguir os passos abaixo:

1. Em appsettngs dentro da camada da api do projeto, deve colocar a linha de conexão do banco de dados postgree
2. Utilizado Migrations para gerar o banco de dados, utilizar os seguintes comandos para que o banco de dados seja criado:
2.1 Utilizar dentro do Visual Studio 2022, a ferramenta Package Manager Console na camada do repository e digitar nessa ordem os seguintes comandos
2.2 add-migration MigrationInitial
2.3 update-database

### Exemplo de Arquivo de Configuração

{
  "ConnectionStrings": {
    "WebApiDatabase": "Host=localhost;Port=5432;Database=BancoAtividades;Username=postgres;Password=123456"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

#### Endpoints

GET /api/exemplo
{
  "mensagem": "Exemplo de resposta"
}