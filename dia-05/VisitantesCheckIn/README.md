# Check-in de Visitantes - Bootcamp Deloitte

Este projeto consiste em uma aplicação de console desenvolvida em .NET, criada como parte das atividades práticas do **Bootcamp Deloitte Dotnet**.
A aplicação simula um sistema de check-in de visitantes, permitindo o registro de entrada, listagem, remoção e filtragem de visitantes durante a execução do programa.

## Objetivo

- Aplicar conceitos fundamentais da linguagem C#
- Praticar Programação Orientada a Objetos
- Trabalhar com listas e manipulação de dados em memória
- Desenvolver menus interativos via terminal
- Exercitar validação de entradas do usuário
- Utilizar consultas com LINQ para filtragem de dados

## Funcionalidades

- Registro de novos visitantes com:
    - Nome
    - Identificador único
    - Documento
    - Horário de chegada
    - Indicação de primeira visita
- Listagem de todos os visitantes registrados
- Registro de saída (remoção) de visitantes
- Filtragem de visitantes que estão no local pela primeira vez
- Menu interativo para navegação no sistema

## Estrutura da Aplicação

- Classe **Visitantes**
    - Representa a entidade visitante
    - Armazena dados pessoais e informações de check-in
- Classe **Program**
    - Responsável pela interação com o usuário
    - Controle do fluxo da aplicação e exibição do menu

## Conceitos Trabalhados

- Programação Orientada a Objetos
- Encapsulamento
- Listas genéricas (**List<T>**)
- LINQ (**Any**, **Where**, **FirstOrDefault**)
- Manipulação de datas e horários (**DateTime**)
- Controle de fluxo com **switch** e **if**
- Geração de identificadores únicos

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
cd /dia-05
cd /VisitantesCheckIn
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

**1.** Registrar novo visitante
**2.** Listar visitantes
**3.** Registrar saída de visitante
**4.** Filtrar por primeira visita
**5.** Sair

As opções são selecionadas digitando o número correspondente no terminal.

## Observações

- Os dados da conta são mantidos apenas em memória durante a execução do programa.
- Não há persistência em banco de dados ou arquivos.
- O projeto possui finalidade exclusivamente educacional.
- As regras de negócio foram simplificadas para fins de aprendizado.






