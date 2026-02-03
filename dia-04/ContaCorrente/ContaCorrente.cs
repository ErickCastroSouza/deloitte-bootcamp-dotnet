namespace ContaCorrente;

public class ContaCorrente
{
    private int numero;
    private double saldo = 0.0;
    private bool especial;
    private double limite;

    public int getNumero()
    {
        return numero;
    }

    public void setNumero(int numero)
    {
        this.numero = numero;
    }

    public double getSaldo()
    {
        return saldo;
    }

    public void setSaldo(double saldo)
    {
        this.saldo = saldo;
    }

    public bool getEspecial()
    {
        return especial;
    }

    public void setEspecial(bool especial)
    {
        this.especial = especial;
    }

    public double getLimite()
    {
        return limite;
    }

    public void setLimite(double limite)
    {
        this.limite = limite;
    }

    public bool withdraw(double valor)
    {
        double limiteDisponivel = especial ? limite : 0;
        if (valor <= (saldo + limiteDisponivel))
        {
            saldo -= valor;
            return true;
        }
        return false;
    }

    public void deposit(double valor)
    {
        saldo += valor;
    }

    public void consultBalance()
    {
        Console.WriteLine("Saldo atual: " + saldo.ToString("F2"));
    }

    public bool verifySpecialCheck()
    {
        if (especial == true && saldo < 0)
        {
            Console.WriteLine("Está utilizando cheque especial.");
            return true;
        }
        else
        {
            Console.WriteLine("Não está utilizando cheque especial.");
            return false;
        }  
        
    }
}
