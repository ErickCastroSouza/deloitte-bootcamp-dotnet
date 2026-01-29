namespace BootcampCase1;

class Program
{
    static string path = @"C:\Users\aluno\Desktop\bootcamp_ddt\Case1\bootcamp-deloitte-case-1\";
    static string fileName = "users.txt";
    static string filePath = path + fileName;

    static void Main()
    {
        Console.WriteLine("============= Cadastro de informações =============");

        CriarArquivo();

        string nome = ExibirMensagemNome();
        int idade = ExibirMensagemIdade();

        string linha = $"{nome};{idade}";
        File.AppendAllText(filePath, linha + Environment.NewLine);

        Console.WriteLine("Usuário salvo com sucesso!");
    }

    static string ExibirMensagemNome()
    {
        Console.WriteLine("1 - Digite seu nome completo:");
        string nome = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome) || nome.Length < 2)
        {
            Console.WriteLine("O nome não pode estar vazio ou ter menos de 2 caracteres. Tente novamente.");
            return ExibirMensagemNome();
        }

        return nome;
    }

    static int ExibirMensagemIdade()
    {
        Console.WriteLine("2 - Digite sua idade:");
        string idade = Console.ReadLine();

        if (!int.TryParse(idade, out int idadeInt) || idadeInt <= 0)
        {
            Console.WriteLine("Idade inválida. Tente novamente.");
            return ExibirMensagemIdade();
        }

        return idadeInt;
    }

    static void CriarArquivo()
    {
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
    }
}
