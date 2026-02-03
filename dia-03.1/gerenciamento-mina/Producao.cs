

class Producao
{
   private int id;
   private string minaCodigo;
   private DateTime data;
   private decimal volume;

   public int getId()
   {
      return this.id;
   }

   public void setId()
   {
      
   }

   public string getMinaCodigo()
   {
      return this.minaCodigo;
   }

   public void setMinaCodigo()
   {
      
   }

   public DateTime getData()
   {
      return this.data;
   }

   public int refinarMinerio(Minerio pMinerio, Refinamento refinamento)
   {
      switch (refinamento) {
         case Refinamento.Granularidade:
               return 0;
      }
         
      return this.quantidadeFinalRefinamento(pMinerio);
   }

   private int quantidadeFinalRefinamento(Minerio pMinerio) {
      return 1;
    }
}





