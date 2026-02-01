namespace ContaCorrente;

class Program
{
    static void Main(string[] args)
    {
        ContaCorrente conta = new ContaCorrente();

        while (true)
        {
            buildConsole(conta);
        }
        
    }

    static void buildConsole(ContaCorrente conta)
    {
        Console.WriteLine("=== Sistema de Conta Corrente ===\n");

        setAccountNumber(conta);
        setAccountStatus(conta);
        chooseOptions(conta);
        consultBalance(conta);
    }

    static void setAccountNumber(ContaCorrente conta)
    {
        Console.WriteLine("Digite o número da conta:\n");
        int numero = int.Parse(Console.ReadLine() ?? "0");
        conta.setNumero(numero);
    }

    static void setAccountStatus(ContaCorrente conta)
    {
        Console.WriteLine("A conta é especial? (true/false):\n");
        bool especial = bool.Parse(Console.ReadLine() ?? "false");
        conta.setEspecial(especial);

        if (especial == true)
        {
            Console.WriteLine("A conta é especial.\n");
            conta.setEspecial(especial);
        }
            
        else if(especial == false)
        {
            Console.WriteLine("A conta não é especial.");
            conta.setEspecial(especial);
        }
            
        else
        {
            Console.WriteLine("Valor inválido, digite true ou false.");
            return;
        }

        if (especial)
        {
            Console.WriteLine("Digite o limite da conta:");
            double limite = double.Parse(Console.ReadLine() ?? "0");
            conta.setLimite(limite);
        }
    }

    static void chooseOptions(ContaCorrente conta)
    {
        Console.WriteLine("Escolha uma opção:\n1 - Sacar\n2 - Depositar\n3 - Consultar Saldo\n4 - Sair");
        int opcao = int.Parse(Console.ReadLine() ?? "0");

        while(true){
            if(opcao >=1 && opcao <=4){
                break;
            }
            Console.WriteLine("Opção inválida. Escolha uma opção:\n1 - Sacar\n2 - Depositar\n3 - Consultar Saldo\n4 - Sair");
            opcao = int.Parse(Console.ReadLine() ?? "0");
        }
        switch (opcao)
        {
            case 1:
                Console.WriteLine("Opção de saque selecionada.");
                moneyWithdraw(conta);
                chooseOptions(conta);
                break;
            case 2:
                moneyDeposit(conta);
                chooseOptions(conta);
                break;
            case 3:
                consultBalance(conta);
                chooseOptions(conta);
                break;
            case 4:
                Console.WriteLine("Saindo do sistema.");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida.");
                chooseOptions(conta);
                break;
        }
    }

    static void moneyWithdraw(ContaCorrente conta)
    {
        Console.WriteLine("Digite o valor para saque:");
        double valorSaque = double.Parse(Console.ReadLine() ?? "0");
        bool saqueRealizado = conta.withdraw(valorSaque);

        if (saqueRealizado)
        {
            Console.WriteLine($"Saque de {valorSaque} realizado com sucesso.");
        }
        else
        {
            Console.WriteLine($"Não foi possível realizar o saque de {valorSaque}.");
        }
    }

    static void moneyDeposit(ContaCorrente conta)
    {
        Console.WriteLine("Digite o valor para depósito:");
        double valorDeposito = double.Parse(Console.ReadLine() ?? "0");
        conta.deposit(valorDeposito);
        Console.WriteLine($"Depósito de {valorDeposito} realizado com sucesso.");
    }

    static void consultBalance(ContaCorrente conta)
    {
        Console.WriteLine("Consultando saldo...");
        conta.consultBalance();
    }


}
