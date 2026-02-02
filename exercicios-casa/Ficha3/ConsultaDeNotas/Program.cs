using ConsultaDeNotas;

class Program
{
    static void Main(string[] args)
    {
        Turma turmaA = CriarTurma();

        while (true) 
        {
            BuildConsole();
        }
    }

    static Turma CriarTurma()
    {
        Turma turmaA = new Turma("Turma A - Bootcamp .NET");

        // Aluno 1
        Aluno aluno1 = new Aluno(
            "João Silva",
            12345,
            new List<string> { "Matemática", "Programação", "Banco de Dados" },
            new List<double> { 8.5, 9.0, 7.5 }
        );

        // Aluno 2
        Aluno aluno2 = new Aluno(
            "Maria Santos",
            12346,
            new List<string> { "Física", "Química", "Matemática" },
            new List<double> { 9.2, 8.8, 9.5 }
        );

        // Aluno 3
        Aluno aluno3 = new Aluno("Pedro Costa");
        aluno3.setMatricula(12347);
        aluno3.setDisciplinas(new List<string> { "Inglês", "Programação" });
        aluno3.setNotas(new List<double> { 8.0, 8.5 });

        // Aluno 4
        Aluno aluno4 = new Aluno(
            "Ana Oliveira",
            12348,
            new List<string> { "Programação", "Banco de Dados", "Sistemas Distribuídos" },
            new List<double> { 9.5, 9.2, 8.9 }
        );

        // Adicionando alunos à turma
        turmaA.AdicionarAluno(aluno1);
        turmaA.AdicionarAluno(aluno2);
        turmaA.AdicionarAluno(aluno3);
        turmaA.AdicionarAluno(aluno4);
        return turmaA;
    }

    static void BuildConsole()
    {
        Console.WriteLine("=====================================");
        Console.WriteLine("  SISTEMA DE CONSULTA DE NOTAS");
        Console.WriteLine("=====================================\n");

        ChooseOption();
    }

    static void ChooseOption()
    {
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1. Pesquisar aluno por nome");
        Console.WriteLine("2. Exibir todos os alunos");
        Console.WriteLine("3. Sair");
        Console.Write("Opção: ");
        string choice = Console.ReadLine() ?? "";

        switch (choice)
        {
            case "1":
                PesquisarAluno();
                break;
            case "2":
                ExibirTurma();
                break;
            case "3":
                Console.WriteLine("Saindo do sistema...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                ChooseOption();
                break;
        }
    }

    static void PesquisarAluno()
    {
        Turma turmaA = CriarTurma();

        Console.Write("\nDigite o nome do aluno que deseja buscar: ");
        string nomeBusca = Console.ReadLine() ?? "";

        turmaA.ExibirAlunoPorNome(nomeBusca);
    }

    static void ExibirTurma()
    {
        Turma turmaA = CriarTurma();
        turmaA.ExibirTodos();
    }
}
