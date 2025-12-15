# Polling Project – Online Questionnaire System

Sistema de Questionários Online desenvolvido em **.NET**, com foco em **pesquisas públicas em larga escala**, como pesquisas eleitorais.  
A solução foi arquitetada considerando **escalabilidade**, **clareza de responsabilidades**, **proteção de regras de negócio** e **facilidade de avaliação e execução**.

---

## Objetivo

Permitir a criação de questionários públicos e a coleta de respostas por milhares de usuários, garantindo regras de domínio como:

- Um usuário responde um questionário apenas uma vez
- Uma pergunta não pode ser respondida duas vezes na mesma submissão
- Resultados podem ser consultados de forma agregada

---

## Arquitetura da Solução (.NET)

A aplicação foi construída utilizando **.NET 8** e segue princípios de **Clean Architecture** e **Domain-Driven Design (DDD)**.

### Estrutura das camadas

- Polling.Domain
- Polling.Application
- Polling.Infrastructure
- Polling.Api


### Justificativa

- Separação clara de responsabilidades
- Isolamento das regras de negócio
- Facilidade de manutenção e evolução
- Independência de frameworks no domínio

---

## Camadas da Aplicação

### Polling.Domain

Contém o **modelo de domínio** e as regras de negócio:

- **Aggregate Roots**
  - Questionnaire
  - Response
- **Entities internas**
  - Question
  - Option
- **Value Objects**
  - Answer
  - Fingerprint

Exemplos de regras protegidas no domínio:

- Um fingerprint só pode responder um questionário uma vez
- Uma resposta não pode conter duas answers para a mesma pergunta

O domínio **não depende de nenhuma tecnologia externa**.

---

### Polling.Application

Responsável pela **orquestração dos casos de uso**:

- Services (QuestionnaireService, ResponseService, ResultService)
- DTOs de aplicação
- Conversão entre domínio e modelos de saída

Nesta camada:
- Não há acesso direto ao banco
- Não há lógica de infraestrutura
- Os services coordenam entidades e repositórios

---

### Polling.Infrastructure

Responsável pela **persistência e integração técnica**:

- Entity Framework Core
- PollingDbContext
- Implementações de repositórios
- Migrations
- Read Models para consultas agregadas

### Justificativa do Entity Framework Core

- Integração nativa com .NET
- Suporte a migrations
- Facilidade de troca de banco
- Clareza no mapeamento relacional

Para facilitar a execução local, foi utilizado **SQLite**.

---

### Polling.Api

Camada de **exposição Web** construída com **ASP.NET Core Web API**.

Responsabilidades:
- Controllers REST
- DTOs de Request e Response
- Tratamento de erros HTTP
- Swagger / OpenAPI

Os controllers:
- Não contêm regras de negócio
- Não acessam diretamente o Entity Framework
- Apenas adaptam HTTP para a camada Application

---

## Arquitetura Web (ASP.NET)

### Componente Web escolhido

- ASP.NET Core Web API

### Justificativa

- Padrão moderno para APIs REST
- Independente de tecnologia de front-end
- Facilita integração com web, mobile e ferramentas como Postman

---

## Integração Front-end ↔ Back-end

- Protocolo: **HTTP / HTTPS**
- Formato: **JSON**
- Estilo: **REST**

O Swagger funciona como documentação viva e permite testar todos os endpoints sem ferramentas externas.

---

## Endpoints Principais

### Criar questionário

- POST /api/questionnaires

### Submeter resposta

- POST /api/responses

### Consultar resultados agregados

- GET /api/results/{questionnaireId}


---

## Testes da Aplicação

A aplicação pode ser testada através de:

1. **Swagger (OpenAPI)** – Interface web
2. **Postman ou qualquer cliente HTTP**

Após executar o projeto, acesse:

- https://localhost:{porta}/swagger
