# Projeto de Registro de Visitantes – Bootcamp Deloitte

Este projeto consiste em uma aplicação de console desenvolvida em .NET, criada como parte das atividades práticas do Bootcamp da Deloitte.
A aplicação tem como objetivo simular um sistema básico de registro e consulta de visitantes, permitindo o cadastro e a visualização de informações durante a execução do programa.

## Objetivo

- Aplicar conceitos fundamentais da linguagem C#
- Praticar o desenvolvimento de aplicações de console em .NET
- Trabalhar com classes e listas de objetos
- Exercitar organização de dados em memória
- Desenvolver menus interativos via terminal

## Funcionalidades

- Cadastro de visitantes com os seguintes dados:
    - Nome
    - Identificador
    - Documento
    - Data e hora do registro
    - Indicação de primeira visita
- Listagem de visitantes cadastrados
- Busca de visitante por critérios definidos
- Menu de navegação via console

## Estrutura da aplicação

- Classe **Visitors** representando a entidade visitante
- Lista em memória para armazenamento dos registros
- Menu principal exibido no terminal
- Métodos responsáveis pela exibição do menu e escolha de opções

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
cd /dia-02
cd /Case2.1
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

## Funcionamento do menu

Ao iniciar a aplicação, o usuário pode selecionar uma das seguintes opções:

- Cadastro de Visitante
- Listar Visitantes
- Buscar Visitante

A navegação é realizada por meio da digitação do número correspondente no console.

## Observações

- Os dados são armazenados apenas em memória durante a execução do programa.
- Ao encerrar a aplicação, os registros são perdidos.
- O projeto possui caráter exclusivamente educacional.
- A aplicação encontra-se em desenvolvimento e pode receber novas funcionalidades.