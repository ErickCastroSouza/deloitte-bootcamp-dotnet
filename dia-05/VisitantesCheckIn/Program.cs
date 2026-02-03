namespace VisitantesCheckIn
{
    class Program
    {

        static List<Visitantes> visitantes = new List<Visitantes>();
        static void Main(string[] args)
        {
            BuildConsole();
        }

        static void BuildConsole()
        {
            Console.WriteLine("Bem vindo ao sistema de Check-In de Visitantes!");

            ChooseOption();
        }

        static void ChooseOption()
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Registrar novo visitante");
            Console.WriteLine("2 - Listar visitantes");
            Console.WriteLine("3 - Registrar saída de visitante");
            Console.WriteLine("4 - Filtrar por primeira visita");
            Console.WriteLine("0 - Sair");

            string option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    RegisterVisitor();
                    break;
                case "2":
                    ListVisitors();
                    break;
                case "3":
                    RemoveVisitor();
                    break;
                case "4":
                    FilterFirstTimeVisitors();
                    break;
                case "0":
                    Console.WriteLine("Saindo do sistema. Até logo!");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    ChooseOption();
                    break;
            }
        }

        static void RegisterVisitor()
        {
            Console.WriteLine("Registrar novo visitante:");

            Console.Write("Nome do visitante: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Documento do visitante: ");
            string documento = Console.ReadLine() ?? "";

            DateTime horarioChegada = DateTime.Now;

            Console.Write("É a primeira vez que o visitante vem? (s/n): ");
            string primeiraVezInput = Console.ReadLine() ?? "n";

            bool isPrimeiraVez = primeiraVezInput.ToLower() == "s";

            int id;
            do
            {
                id = new Random().Next(1000, 9999);
            } while (visitantes.Any(v => v.id == id));

            visitantes.Add(new Visitantes(
                nome,
                id,
                documento,
                horarioChegada,
                isPrimeiraVez
            )); 


            Console.WriteLine("Visitante registrado com sucesso!");

            ChooseOption();
        }

        static void ListVisitors()
        {
            Console.WriteLine("Lista de visitantes:");

            if (visitantes.Count == 0)
            {
                Console.WriteLine("Nenhum visitante registrado.");
            }
            else
            {
                foreach (var visitante in visitantes)
                {
                    Console.WriteLine($"Nome: {visitante.nome}, ID: {visitante.id}, Documento: {visitante.documento}, Horário de Chegada: {visitante.horarioChegada}, Primeira Vez: {visitante.isPrimeiraVez}");
                }
            }

            ChooseOption();
        }

        static void RemoveVisitor()
        {
            Console.WriteLine("Remover visitante:");

            Console.Write("Digite o nome do visitante a ser removido: ");
            string nomeInput = Console.ReadLine() ?? "";

            var visitante = visitantes.FirstOrDefault(v => v.nome == nomeInput);
                if (visitante != null)
                {
                    visitantes.Remove(visitante);
                    Console.WriteLine("Visitante removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Visitante não encontrado.");
                }
            ChooseOption();
        }

        static void FilterFirstTimeVisitors()
        {
            Console.WriteLine("Visitantes que estão aqui pela primeira vez:");

            var primeiraVez = visitantes.Where(v => v.isPrimeiraVez).ToList();
            if (primeiraVez.Count == 0)
            {
                Console.WriteLine("Nenhum visitante primeira vez registrado.");
            }
            else
            {
                foreach (var visitante in primeiraVez)
                {
                    Console.WriteLine($"Nome: {visitante.nome}, ID: {visitante.id}, Documento: {visitante.documento}");
                }
            }

            ChooseOption();
        }


    }
}