# Check-in de Visitantes

Sistema de Controle de Check-In de Visitantes

Como utilizar:

Ao rodar um "dotnet run" o usuário poderá escolher entre 5 opções pelo console:

1 - Registrar novo visitante
2 - Listar visitantes
3 - Registrar saída de visitante
4 - Filtrar por primeira visita
0 - Sair

O usuário escolhe a opção por digitar o número correspondente no console e dar ENTER.

As opções são controladas por um método switch, cada opção é um case diferente.

Ao registrar um visitante o usuário pode digitar um nome, documento e se é a primeira vez que o visitante está no local. O script pega essas informações e as reúne em uma List, junto do horário de chegada e de um Id gerado aleatóriamente.

Ao escolher a opção de listar visitantes o script usa um foreach para ler toda a List e imprimir no console toda a lista com todas as informações de cada visitante de forma ordenada.

Ao escolher a opção de registrar a saída de visitante, o script simplesmente remove da List o visitante que o usuário digitar o nome

Ao escolher a opção de filtrar por primeira visita, o script simplesmente roda um foreach pela lista e verifica em quais visitantes o bool isPrimeiraVez está como true, e retorna ao usuário apenas esses usuários.

Ao escolher a opção de sair, o script simplesmente sai do switch do qual todas as opções estão armazenadas.







