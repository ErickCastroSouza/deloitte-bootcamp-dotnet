class Estoque
{
   List<string> itensEstocados = new List<string>();
   private int id;
   private int producaoId;
   private decimal quantidade;
   private string local;

   public int getId()
   {
      return this.id;
   }

   public void setId()
   {
      
   }

   public int getProducaoId()
   {
      return this.producaoId;
   }

   public void setProducaoId()
   {
      
   }

   public decimal getQuantidade()
   {
      return this.quantidade;
   }

   public void setQuantidade()
   {
      
   }

   public string getLocal()
   {
      return this.local;
   }

   public void setLocal()
   {
      
   }

   private void adicionarEstoque()
   {
      Console.WriteLine("Digite o nome do item a ser estocado:");
      string item = Console.ReadLine() ?? "";

      if (item == null )
        {
            Console.WriteLine("\nO nome do produto é inválido, tente novamente!\n");
        }
      else
      {
         itensEstocados.Add(item);
      }
      
   }

   public void acessarEstoque()
   {
      Console.WriteLine("Digite sua senha para acessar o estoque");
      string input = Console.ReadLine() ?? "";

      if(input == "senha-do-estoque")
      {
         listarEstoque();
      }
      else
      {
         Console.WriteLine("Senha incorreta");
      }
   }

   private void listarEstoque()
   {
      
   }


   

   
}

