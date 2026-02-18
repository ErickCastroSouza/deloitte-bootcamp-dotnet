# API simples de uma mineradora fictícia

Esta é uma API REST simples desenvolvida para fins educacionais e demonstrativos, simulando o backend de uma mineradora fictícia.
O projeto foi criado com o objetivo de praticar a construção de APIs, integração com banco de dados e operações CRUD completas.

## Funcionalidades
- Integração com banco de dados PostgreSQL;
- Integração completa de CRUD:
    - GET - Consulta registros
    - POST - Criação de novos registros
    - PUT - Atualização de registros existentes
    - DELETE - Remoção de registros
- Estrutura de API REST seguindo boas práticas
- Persistência de dados em banco relacional
- Ambiente preparado para execução com Docker
- Cache de dados estratégicos com Redis
- Regras de negócio aplicadas via Service Layer
- Classificação de qualidade do minério
- Cálculo de preço por tonelada
- Cálculo de valor total do lote
- Cálculo de penalidade por umidade
- Registro de movimentação de lotes
- Controle de avanço de status do lote

## Tecnologias utilizadas
- C#/.NET - Desenvolvimento da API
- PostgreSQL - Banco de dados relacional
- DBeaver - Gerenciamento e visualização do banco de dados
- Docker - Containerização da aplicação e do banco
- Insomnia - Testes e consumo da API
- Redis - Cache em memória para otimização de performance

## Objetivo do Projeto
Este projeto não representa um sistema real de produção.
Seu propósito é servir como exemplo prático para:
- Estudo de APIs REST em .NET
- Integração com PostgreSQL
- Uso de Redis para cache
- Organização de código em camadas (Controllers + Service)
- Uso de containers com Docker
- Testes de endpoints

# Como executar o projeto

## Pré requisitos
Certifique-se de ter instalado em sua máquina:
- **.NET SDK 10** 
- **Docker**
- **PostgreSQL** (caso opte por rodar sem Docker)
- **Insomnia** ou **Postman** (para testes)

# Executando com Docker (Recomendado)
**1.** Clone o repositório:
```bash
git clone https://github.com/ErickCastroSouza/deloitte-bootcamp-dotnet.git
cd deloitte-bootcamp-dotnet
cd /dia-06
cd /MinhaApi
```

**2.** Suba os containers:
```bash
docker compose up -d
```

**3.** Aguarde a inicialização dos serviços.

**4.** A API estará disponível em:
```arduino
http://localhost:5000
```

**5.** Utilize o Insomnia ou Postman para testar os endpoints.

## Executando Localmente (sem Docker)

**1.** Clone o repositório:
```bash
git clone https://github.com/ErickCastroSouza/deloitte-bootcamp-dotnet.git
cd deloitte-bootcamp-dotnet
cd /dia-06
cd /MinhaApi
```

**2.** Configure a string de conexão com o PostgreSQL no arquivo:
```pgsql
appsettings.json
```
Exemplo:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=mineradora;Username=postgres;Password=postgres"
  }
}
```

**3.** Restaure as dependências:
```bash
dotnet restore
```

**4.** Execute a aplicação:
```bash
dotnet run
```

## Testando a API
- Importe as requisições no **Insomnia**
- Ou utilize chamadas HTTP padrão para testar os métodos:
    - **GET**
    - **POST**
    - **PUT**
    - **DELETE**

### Classificar qualidade do lote

**GET** /api/lotes/{id}/classificar

Classifica automaticamente o lote com base em seus atributos (teor, umidade, etc).

**Resposta:** 
```json
{
  "id": 1,
  "codigoLote": "LT-001",
  "qualidade": "Alta"
}
```

### Calcular preço do lote

**GET** /api/lotes/{id}/preco

Calcula:
  - Qualidade
  - Preço por tonelada
  - Quantidade de toneladas
  - Valor total

**Resposta:**
```json
{
  "id": 1,
  "codigoLote": "LT-001",
  "qualidade": "Alta",
  "precoPorTonelada": 350,
  "toneladas": 100,
  "valorTotal": 35000
}
```

### Registrar movimentação do lote

**POST** /api/lotes/{id}/mover

Permite registrar mudança de local e status do lote.

**Body:**
```json
{
  "local": "Porto de Santos",
  "status": 2
}
```

**Descrição:**
- Atualiza o local do lote
- Atualiza o status
- Persiste no banco

### Avançar status do lote

**POST** /api/lotes/{id}/avancar-status

Avança automaticamente o status do lote para o próximo estágio do fluxo operacional.

**Exemplo:**

- Extraído → Processando
- Processando → Estocado
- Estocado → Enviado

### Calcular penalidade por umidade

**GET** /api/lotes/{id}/penalidade

Calcula penalidade financeira baseada no percentual de umidade do lote.

**Resposta:**
```json
{
  "id": 1,
  "codigoLote": "LT-001",
  "umidade": 12.5,
  "penalidade": 1500
}
```

## Onde o Redis é utilizado?

O Redis pode ser utilizado para:
  - Cachear classificação de qualidade
  - Cachear cálculo de preço
  - Reduzir consultas repetidas ao banco
  - Melhorar performance em cenários de alto volume
Exemplo de estratégia:
  - Ao consultar /preco, primeiro verifica no Redis.
  - Se existir cache → retorna imediatamente.
  - Se não → calcula, salva no Redis e retorna.