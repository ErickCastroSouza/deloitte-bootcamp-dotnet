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
        try
        {
            Console.WriteLine("Digite o número da conta:\n");
            int numero = int.Parse(Console.ReadLine() ?? "0");
            conta.setNumero(numero);
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida. Digite um número inteiro válido.");
            setAccountNumber(conta);
        }
    }
    static void setAccountStatus(ContaCorrente conta)
    {
        try
        {
            Console.WriteLine("A conta é especial? (true/false):\n");
            bool especial = bool.Parse(Console.ReadLine() ?? "false");
            conta.setEspecial(especial);

            if (especial == true)
            {
                Console.WriteLine("A conta é especial.\n");
                conta.setEspecial(especial);
                Console.WriteLine("Digite o limite da conta:");
                double limite = double.Parse(Console.ReadLine() ?? "0");
                conta.setLimite(limite);
            }
                
            else if(especial == false)
            {
                Console.WriteLine("A conta não é especial.");
                conta.setEspecial(especial);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida. Digite 'true' ou 'false' para a conta especial, e um número válido para o limite.");
            setAccountStatus(conta);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }

    static void chooseOptions(ContaCorrente conta)
    {
        Console.WriteLine("Escolha uma opção:\n1 - Sacar\n2 - Depositar\n3 - Consultar Saldo\n4 - Sair");
        int opcao = int.Parse(Console.ReadLine() ?? "0");

        while(true){
            if(opcao >=1 && opcao <=4)
            {
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
                Console.WriteLine("Opção de depósito selecionada.");
                moneyDeposit(conta);
                chooseOptions(conta);
                break;
            case 3:
                Console.WriteLine("Opção de consultar saldo selecionada.");
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
        if (valorSaque <= 0)
        {
            Console.WriteLine("Valor de saque inválido. O valor deve ser maior que zero.");
            return;
        }
        bool saqueRealizado = conta.withdraw(valorSaque);

        if (saqueRealizado)
        {
            Console.WriteLine($"Saque de {valorSaque.ToString("F2")} realizado com sucesso.");
        }
        else
        {
            Console.WriteLine($"Não foi possível realizar o saque de {valorSaque.ToString("F2")}.");
        }
    }

    static void moneyDeposit(ContaCorrente conta)
    {
        Console.WriteLine("Digite o valor para depósito:");
        double valorDeposito = double.Parse(Console.ReadLine() ?? "0");
        if (valorDeposito <= 0)
        {
            Console.WriteLine("Valor de depósito inválido. O valor deve ser maior que zero.");
            return;
        }
        else if (valorDeposito > 10000) 
        {
            Console.WriteLine("Valor de depósito excede o limite permitido de R$ 10.000,00.");
            return;
        }
            conta.deposit(valorDeposito);
            Console.WriteLine($"Depósito de {valorDeposito.ToString("F2")} realizado com sucesso.");

    }

    static void consultBalance(ContaCorrente conta)
    {
        Console.WriteLine("Consultando saldo...");
        conta.consultBalance();
    }


}
