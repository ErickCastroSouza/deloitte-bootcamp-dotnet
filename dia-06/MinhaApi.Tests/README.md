# Mineradora CLI Tester

Aplicação Unix desenvolvida para testar automaticamente a API REST da Mineradora Fictícia.

Essa ferramenta permite validar endpoints, testar regras de negócio, verificar cálculos e simular operações reais diretamente pelo terminal.

Projeto complementar à API desenvolvida em .NET.

## Objetivo

Criar uma ferramenta de linha de comando (CLI) para:
- Testar endpoints CRUD
- Validar cálculos de preço
- Testar classificação de qualidade
- Simular movimentações de lote
- Verificar avanço de status
- Validar penalidade por umidade
- Automatizar testes via terminal Unix
- Facilitar testes rápidos em ambiente local ou Docker

## Tecnologias Utilizadas
- Bash (Shell Script)
- API Mineradora (backend .NET)

## Pré-requisitos

API Mineradora rodando em:
```arduino
http://localhost:5000
```

## Como Executar

**1 -** Clone o repositório:
```bash
git clone https://github.com/ErickCastroSouza/deloitte-bootcamp-dotnet.git
cd deloitte-bootcamp-dotnet
cd /dia-06
cd /MinhaApi.Testes
```

**2 -** Execute o comando:
```bash
dotnet test
```

## O que essa aplicação demonstra?
 - Consumo de API via terminal Unix
 - Automação de testes REST
 - Integração com backend .NET
 - Simulação de fluxo real de negócio

## Relação com o Projeto Principal

Esta aplicação foi criada para testar a:

API Mineradora Fictícia desenvolvida em .NET + PostgreSQL + Redis.

Ela simula interações reais com os lotes de minério através de comandos Unix.