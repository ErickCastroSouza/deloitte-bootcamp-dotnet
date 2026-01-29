namespace BootcampCase3;

public class Product
{
    public string Name {get; set; } = string.Empty;
    public decimal Value {get; set; }
}

class Program
{

    static List<Product> products = new List<Product>();

    static void Main()
    {
        Console.WriteLine("\n============Cadastro de produtos============\n");
        
        while(true)
        {
            BuildConsole();
        }
    }

    static void BuildConsole()
    {
        Console.WriteLine("1. Adicionar produtos");
        Console.WriteLine("2. Remover produto");
        Console.WriteLine("3. Listar produtos");
        Console.WriteLine("4. Editar produtos");
        Console.WriteLine("5. Sair");

        string userOption = Console.ReadLine() ?? "";

        ChooseOption(userOption);

    }

    static void ChooseOption(string userOption)
    {
        if (userOption == "1")
        {
            AddProduct();
        }
        else if (userOption == "2")
        {
            RemoveProduct();   
        }
        else if (userOption == "3")
        {
            ListProducts();
        }
        else if (userOption == "4")
        {
            EditProducts();
        }
        else if (userOption == "5")
        {
            Exit();
        }
        else
        {
            Console.WriteLine("\nDigite uma opção válida\n");
        }
    }

    static void AddProduct()
    {
        Console.WriteLine("\nDigite o nome do produto:\n");

        string productName = Console.ReadLine() ?? "";

        if (products.Any(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase)) || string.IsNullOrWhiteSpace(productName))
        {
            Console.WriteLine("\nO produto inválido ou já existe, tente novamente!\n");
        }
        else
        {
            decimal productValue = ReadProductValue();

            if (productValue <= 0)
            {
                return;
            }

            products.Add(new Product
            {
                Name = productName,
                Value = productValue
            });
            Console.WriteLine("\nProduto adicionado com sucesso\n");
        }
    }

    static decimal ReadProductValue()
{
    while(true)
    {
        try
        {
            Console.WriteLine("\nQual o valor do produto?\n");
            string input = Console.ReadLine() ?? "";

            decimal value = Convert.ToDecimal(input);

            if (value <= 0)
                throw new Exception("\nValor deve ser maior que zero.");

            return value;
        }
        catch (FormatException)
        {
            Console.WriteLine("\nValor inválido. Digite apenas números.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}

    static void RemoveProduct()
    {
        Console.WriteLine("\nDigite o nome do produto que deseja remover");

            string productName = Console.ReadLine() ?? "";

            Product productToRemove = products.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (productToRemove == null)
            {
                Console.WriteLine("\nO produto não existe");
            }
            else
            {
                products.Remove(productToRemove);
                Console.WriteLine("\nProduto removido com sucesso");
            }
    }

    static void EditProducts()
    {

        if (products.Count == 0)
        {
            Console.WriteLine("\nA lista está vazia\n");
            return;
        }

        while(true)
        {
            ListProducts();

            Console.WriteLine("\nDigite o nome do produto que deseja editar:");

            string oldName = Console.ReadLine() ?? "";

            Product product = products.FirstOrDefault(p => p.Name.Equals(oldName, StringComparison.OrdinalIgnoreCase));

            if (product == null)
            {
                Console.WriteLine("\nProduto não encontrado.");
                return;
            }

            Console.WriteLine("\nNovo nome para o produto (Ou ENTER para manter)");
            string newName = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(newName) &&
            !products.Any(p => p.Name.Equals(newName, StringComparison.OrdinalIgnoreCase)))
            {
                product.Name = newName;
            }
            else
            {
                Console.WriteLine("o novo nome não pode ser o mesmo de um produto já existente.");
                return;
            }

            decimal newValue = ReadProductValue();
            if (newValue > 0)
            {
                product.Value = newValue;
            }

            Console.WriteLine("\nProduto atualizado com sucesso!");
            return;
        }

    }

    static void Exit()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("\nO estoque não pode estar vazio, adicione elementos antes de sair.\n");
            return;
        }
        else
        {
            Environment.Exit(0);
        }
    }



    static void ListProducts()
    {
        Console.WriteLine("\n============Lista Completa============\n");

        if (products.Count == 0)
    {
        Console.WriteLine("\nNenhum produto cadastrado.");
        return;
    }

        foreach(var product in products)
        {
            Console.WriteLine($"Produto: {product.Name} | Valor: R$ {product.Value:F2}");
        }
    }
}
