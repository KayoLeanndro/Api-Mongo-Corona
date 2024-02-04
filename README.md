# API MongoDB de Controle de Infectados

Este é um projeto de API desenvolvido em C# utilizando .NET Core para controlar informações sobre infectados pelo COVID-19. Ele usa o MongoDB como banco de dados para armazenar e gerenciar os dados dos infectados.

## Configuração

Antes de executar a API, você precisa configurar a conexão com o banco de dados MongoDB. Para isso, siga as etapas abaixo:

1. Certifique-se de ter o MongoDB instalado e em execução em sua máquina ou em um servidor acessível.
2. No arquivo `appsettings.json`, ajuste a seção `"ConnectionString"` conforme necessário para apontar para o seu servidor MongoDB. Por exemplo:
   ```json
   "ConnectionString": "mongodb://localhost:27017/NomeDoBancoDeDados"

# Endpoints da API

## POST /Infectado/SalvarInfectado
Adiciona um novo infectado ao banco de dados.

Corpo da solicitação (JSON):

```
{
  "dataNascimento": "yyyy-mm-dd",
  "sexo": "string",
  "latitude": double,
  "longitude": double
}
```

## GET /Infectado/ObterInfectados
Retorna todos os infectados armazenados no banco de dados.

## PUT /Infectado/AtualizarInfectados
Atualiza as informações de um infectado no banco de dados com base na data de nascimento.

Corpo da solicitação (JSON):
```
{
  "dataNascimento": "yyyy-mm-dd",
  "sexo": "string",
  "latitude": double,
  "longitude": double
}
```

## DELETE /Infectado/DeletarInfectados
Exclui um infectado do banco de dados com base na data de nascimento.

Parâmetro da solicitação:

dataNasc: Data de nascimento do infectado a ser excluído (no formato "yyyy-mm-dd").

## Forma de rodar o codigo:

bash
Copy code
dotnet restore
dotnet build
dotnet run
A API estará em execução localmente em https://localhost:5001.

Documentação da API
A documentação da API está disponível através do Swagger UI. Após executar o projeto, acesse https://localhost:5001/swagger no seu navegador para explorar os endpoints da API.
