# Projeto de Conta Corrente – Bootcamp Deloitte

Este projeto consiste em uma aplicação de console desenvolvida em .NET, criada como parte das atividades práticas do **Bootcamp Deloitte Dotnet.**
A aplicação simula um sistema básico de conta corrente, permitindo operações financeiras como saque, depósito e consulta de saldo, incluindo o uso de cheque especial.

## Objetivo

- Aplicar conceitos fundamentais da linguagem C#
- Praticar Programação Orientada a Objetos
- Trabalhar com encapsulamento por meio de métodos get e set
- Simular regras básicas de um sistema bancário
- Desenvolver interação com o usuário via terminal
- Exercitar validação de entradas e controle de fluxo

## Funcionalidades

- Cadastro do número da conta
- Definição do tipo de conta:
    - Conta comum
    - Conta especial (com limite)
- Depósito de valores com validação de limite
- Saque com verificação de saldo e cheque especial
- Consulta de saldo em tempo real
- Verificação de utilização de cheque especial
- Menu interativo via console

## Estrutura da Aplicação

- Classe **ContaCorrente**
    - Armazena os dados da conta
    - Controla saldo, limite e tipo de conta
    - Implementa regras de saque e depósito
- Classe **Program**
    - Responsável pela interação com o usuário
    - Exibição do menu e controle do fluxo da aplicação

## Conceitos Trabalhados

- Programação Orientada a Objetos
- Encapsulamento
- Métodos públicos e privados
- Validação de dados de entrada
- Controle de fluxo com **while**, **if** e **switch**
- Manipulação de exceções
- Formatação de valores monetários

## Tecnologias utilizadas

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
cd /dia-04
cd /ContaCorrente
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

## Funcionamento do Menu

Ao executar a aplicação, o usuário pode escolher entre as seguintes opções:

**1.** Sacar
**2.** Depositar
**3.** Consultar saldo
**4.** Sair

As opções são selecionadas digitando o número correspondente no terminal.

## Observações

- Os dados da conta são mantidos apenas em memória durante a execução do programa.
- Não há persistência em banco de dados ou arquivos.
- O projeto possui finalidade exclusivamente educacional.
- As regras de negócio foram simplificadas para fins de aprendizado.
