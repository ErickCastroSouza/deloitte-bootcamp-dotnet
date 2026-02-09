# Projeto de Gestão de Mina e Estoque – Bootcamp Deloitte

Este projeto consiste em uma aplicação de estudos desenvolvida em .NET, criada como parte das atividades práticas do **Bootcamp Deloitte Dotnet.**
O objetivo do projeto é simular, de forma simplificada, processos relacionados à mineração, como extração de minério, produção, refinamento e controle de estoque, aplicando conceitos fundamentais de programação orientada a objetos.

## Objetivos

- Praticar conceitos de Programação Orientada a Objetos (POO) em C#
- Trabalhar com encapsulamento por meio de métodos get e set
- Simular regras de negócio básicas do domínio de mineração
- Exercitar controle de acesso por meio de validação simples (senha)
- Compreender o relacionamento entre classes e entidades

## Funcionalidades

- Controle de estoque de itens estocados
- Registro e acesso ao estoque mediante validação de senha
- Simulação de extração de minério a partir de uma mina
- Controle de acesso à extração com validação de credenciais
- Representação de minério com código e tipo
- Processo simplificado de produção e refinamento de minério
- Uso de enumeração para tipos de refinamento

## Estrutura da aplicação

- Classe **Estoque**
    - Gerenciamento de itens estocados
    - Controle de acesso ao estoque
- Classe **Mina**
    - Informações da mina
    - Extração controlada de minério
- Classe **Minerio**
    - Representação do minério extraído
- Classe **Producao**
    - Registro de dados de produção
    - Simulação de refinamento de minério
- Enum **Refinamento**
    - Tipos de processos de refinamento

## Conceitos Trabalhados

- Programação Orientada a Objetos
- Encapsulamento
- Métodos públicos e privados
- Enumerações
- Validação de entrada do usuário
- Controle de fluxo
- Organização de regras de negócio

## Tecnologias Utilizadas

- C#
- .NET
- Aplicação de Console
- Terminal

## Como Executar o Projeto

### Pré-requisitos

- **.NET SDK 10** instalado
Verifique instalação com:
```bash
dotnet --version
```

### Execução 

**1.** Clone o repositório:
```bash
git clone https://github.com/ErickCastroSouza/deloitte-bootcamp-dotnet.git
cd deloitte-bootcamp-dotnet
cd /dia-03.1
cd /gerenciamento-mina
```

**2.** Restaure as dependências:
```bash
dotnet restore
```

**3.** Execute a aplicação:
```bash
dotnet run
```

**4.** O menu de opções será exibido diretamente no terminal.

## Observações

- Os dados são armazenados apenas em memória.
- As validações de senha possuem finalidade apenas didática.
- O projeto possui caráter exclusivamente educacional.
- Parte dos métodos encontra-se propositalmente incompleta, visando exercícios de implementação durante o bootcamp.
