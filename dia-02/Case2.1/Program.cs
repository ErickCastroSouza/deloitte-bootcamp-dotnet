using System.Collections;
using System.Linq.Expressions;

namespace BootcampCase2_1;

class Visitors
{
    public string Name {get; set; } = string.Empty;
    public int Id {get; set;}
    public string Document {get; set; } = string.Empty;
    public DateTime Time {get; set; } 
    public bool FirstTime {get; set; }
}


class Program
{

    List<Visitors> visitors = new List<Visitors>();
    static void Main()
    {
        BuildConsole();
    }

    static void BuildConsole()
    {
        Console.WriteLine("===========Registro de Visitantes===========\n");

        Console.WriteLine("1. Cadastro de Visitante");
        Console.WriteLine("2. Listar Visitantes");
        Console.WriteLine("3. Buscar Visitante");


        ChooseOption();
    }

    static void ChooseOption()
    {
        Console.WriteLine("\nEscolha uma opção das opções");
    }
}
