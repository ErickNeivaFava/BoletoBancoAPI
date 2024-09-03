Este repositório contém a implementação de uma API desenvolvida em .NET 6 para o cadastro e gerenciamento de Boletos e Bancos. O objetivo é demonstrar conhecimentos técnicos em .NET, Entity Framework, PostgreSQL, boas práticas de desenvolvimento, e outros conceitos como documentação de API, DTOs, e mapeamento de objetos.

Tecnologias Utilizadas

.NET 6
Entity Framework Core
PostgreSQL
Swagger para documentação da API
Funcionalidades Implementadas


1. Endpoints de Cadastro (POST)

Boleto: Cadastro de boletos com as seguintes propriedades:

Id (Obrigatório)
Nome do Pagador (Obrigatório)
CPF/CNPJ do Pagador (Obrigatório)
Nome do Beneficiário (Obrigatório)
CPF/CNPJ do Beneficiário (Obrigatório)
Valor (Obrigatório)
Data de Vencimento (Obrigatório)
Observação
BancoId (Obrigatório) - Referência para o cadastro de banco

Banco: Cadastro de bancos com as seguintes propriedades:

Id (Obrigatório)
Nome do Banco (Obrigatório)
Código do Banco (Obrigatório)
Percentual de Juros (Obrigatório)


2. Endpoints de Busca (GET)
   
Bancos:

Buscar todos os bancos cadastrados.
Buscar um banco específico utilizando o Código do Banco.

Boletos:

Buscar um boleto específico pelo seu Id.
Se o boleto estiver sendo buscado após a sua Data de Vencimento, o valor é retornado com o juros aplicados do banco relacionado.


3. Validações

Implementação de validação para todos os campos obrigatórios nas entidades Boleto e Banco.
Pontos Extras Implementados (Opcional)
Autenticação utilizando TOKEN.
Criação de DTOs para as entidades.
Utilização do AutoMapper para mapear entre entidades e DTOs.
Separação do projeto em camadas: Controllers, Services, Repositories.
