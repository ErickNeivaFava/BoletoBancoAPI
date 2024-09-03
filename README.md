# API de Boletos e Bancos - Desafio Técnico .NET

Este repositório contém a implementação de uma API RESTful utilizando .NET 6 para gerenciar o cadastro de **Boletos** e **Bancos**. A aplicação foi desenvolvida como parte de um desafio técnico para demonstrar habilidades em desenvolvimento backend com .NET, utilizando Entity Framework, PostgreSQL, e boas práticas de desenvolvimento.

## Tecnologias Utilizadas
- .NET 6
- Entity Framework Core
- PostgreSQL
- Swagger para documentação da API
- AutoMapper (opcional)
- JWT para autenticação (opcional)

## Funcionalidades Implementadas

### Endpoints de Cadastro (POST)

#### 1. Cadastro de Boleto
- `POST /api/boletos`
- Propriedades:
  - `Id` (Obrigatório)
  - `Nome do Pagador` (Obrigatório)
  - `CPF/CNPJ do Pagador` (Obrigatório)
  - `Nome do Beneficiário` (Obrigatório)
  - `CPF/CNPJ do Beneficiário` (Obrigatório)
  - `Valor` (Obrigatório)
  - `Data de Vencimento` (Obrigatório)
  - `Observação` (Opcional)
  - `BancoId` (Obrigatório) - Relacionamento com a entidade Banco

#### 2. Cadastro de Banco
- `POST /api/bancos`
- Propriedades:
  - `Id` (Obrigatório)
  - `Nome do Banco` (Obrigatório)
  - `Código do Banco` (Obrigatório)
  - `Percentual de Juros` (Obrigatório)

### Endpoints de Busca (GET)

#### 1. Buscar Todos os Bancos
- `GET /api/bancos`
- Retorna todos os registros de bancos cadastrados.

#### 2. Buscar Banco por Código
- `GET /api/bancos/{codigoBanco}`
- Retorna o banco correspondente ao `Código do Banco` informado.

#### 3. Buscar Boleto por Id
- `GET /api/boletos/{id}`
- Retorna o boleto correspondente ao `Id` informado.
- Se a consulta for realizada após a `Data de Vencimento`, o valor do boleto é retornado com o juros aplicados, baseado no percentual de juros do banco associado.

### Validações
- Validações implementadas para todos os campos obrigatórios nas entidades **Boleto** e **Banco**.

## Pontos Extras Implementados (Opcional)
- **Autenticação JWT**: Para proteger os endpoints sensíveis da API.
- **DTOs**: Utilização de Data Transfer Objects para a comunicação entre a API e o cliente.
- **AutoMapper**: Para mapeamento automático entre as entidades e os DTOs.
- **Separação em Camadas**: O projeto segue a arquitetura em camadas (Controllers, Services, Repositories) para melhor organização e manutenção do código.

## Como Executar o Projeto

1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/nome-do-repositorio.git
