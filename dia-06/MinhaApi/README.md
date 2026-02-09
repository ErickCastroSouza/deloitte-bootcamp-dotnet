# API simples de uma mineradora fictícia

Esta é uma API REST simples desenvolvida para fins educacionais e demonstrativos, simulando o backend de uma mineradora fictícia.
O projeto foi criado com o objetivo de praticar a construção de APIs, integração com banco de dados e operações CRUD completas.

---
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

---
## Tecnologias utilizadas
- C#/.NET - Desenvolvimento da API
- PostgreSQL - Banco de dados relacional
- DBeaver - Gerenciamento e visualização do banco de dados
- Docker - Containerização da aplicação e do banco
- Insomnia - Testes e consumo da API

---
## Objetivo do Projeto
Este projeto não representa um sistema real de produção.
Seu propósito é servir como exemplo prático para:
- Estudo de APIs REST em .NET
- Integração com PostgreSQL
- Organização de código backend
- Uso de containers com Docker
- Testes de endpoints

---
# Como executar o projeto

## Pré requisitos
Certifique-se de ter instalado em sua máquina:
- **.NET SDK 10** 
- **Docker**
- **PostgreSQL** (caso opte por rodar sem Docker)
- **Insomnia** ou **Postman** (para testes)

---
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

--- 
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

---
## Testando a API
- Importe as requisições no **Insomnia**
- Ou utilize chamadas HTTP padrão para testar os métodos:
    - **GET**
    - **POST**
    - **PUT**
    - **DELETE**




