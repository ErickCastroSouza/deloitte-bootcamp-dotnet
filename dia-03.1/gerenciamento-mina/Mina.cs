
class Mina
{

    private Minerio? minerio = new Minerio();
    private string? codigo;
    private string? nome;
    private decimal? capacidade;

    public string getCodigo()
    {
        return this.codigo;
    }
    public void setCodigo(string pCodigo)
    {
        
    }

    public string getNome()
    {
        return this.nome;
    }
    
    public void setNome(string pNome)
    {
        
    }

    public decimal getCapacidade()
    {
        return (decimal) this.capacidade;
    }

    public void setCapacidade()
    {
        
    }




    public Minerio acessarExtrairMinerio()
    {
        Console.WriteLine("\nDigite a senha:");
        string input = Console.ReadLine();

        if (input == "senha-do-gestor")
        {
            return this.extrairMinerio();
        }
        else
        {
            Console.WriteLine("Senha incorreta.");
            return null;
        }
    }

    private Minerio extrairMinerio()
    {
        minerio.codigo = "1";
        minerio.tipo = "Ouro";

        return minerio;

    }

}


