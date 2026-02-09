# Projeto de Cadastro de Produtos – Bootcamp Deloitte

Este projeto consiste em uma aplicação de console desenvolvida em .NET, criada como parte das atividades práticas do **Bootcamp Deloitte Dotnet**.
A aplicação simula um sistema simples de cadastro e gerenciamento de produtos em estoque, permitindo operações básicas de inclusão, edição, remoção e listagem de itens.

## Objetivo

- Aplicar conceitos fundamentais da linguagem C#
- Praticar o desenvolvimento de aplicações de console em .NET
- Trabalhar com listas e manipulação de objetos em memória
- Exercitar validação de entradas do usuário
- Desenvolver lógica de controle de fluxo e menus interativos

## Funcionalidades

- Cadastro de produtos com:
    - Nome
    - Valor
    - Quantidade em estoque
- Listagem de todos os produtos cadastrados
- Edição de produtos existentes
- Remoção de produtos
- Validação de dados de entrada:
    - Valores numéricos
    - Quantidade maior que zero
    - Nomes duplicados não permitidos
- Menu interativo via terminal

## Estrutura da Aplicação

- Classe **Product** representando a entidade de produto
- Lista em memória para armazenamento dos produtos
- Métodos separados para cada operação:
    - Adicionar produto
    - Remover produto
    - Listar produtos
    - Editar produto
- Controle de fluxo baseado em menu de opções

## Tecnologias Utilizadas

- C#
- .NET
- Aplicação de Console
- Terminal

## Como Executar o Projeto

### Pré requisitos
- .NET SDK 10 instalado
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
cd /Case2
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

**1.** Adicionar produtos
**2.** Remover produto
**3.** Listar produtos
**4.** Editar produtos
**5.** Sair

## Observações

- Os dados são armazenados apenas em memória durante a execução do programa.
- Ao encerrar a aplicação, todas as informações cadastradas são perdidas.
- O projeto possui finalidade exclusivamente educacional.
