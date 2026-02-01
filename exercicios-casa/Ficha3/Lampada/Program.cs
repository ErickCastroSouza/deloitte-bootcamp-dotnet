using System.Numerics;

namespace Lampada;

class Program
{
    static void Main(string[] args)
    {
        interruptor();
    }

    static void interruptor()
    {
        Lampada lamp = new Lampada();

        Console.WriteLine("Quer ligar a lâmpada? (s/n)");
        string resposta = Console.ReadLine() ?? "";

        if (resposta.ToLower() == "s")
        {
            lamp.TurnOn();
        }
        else if(resposta.ToLower() == "n")
        {
            lamp.TurnOff();
        }
        else
        {
            Console.WriteLine("Resposta inválida. A lâmpada permanecerá desligada.");
            lamp.TurnOff();
        }

        Console.WriteLine("Estado final da lâmpada: " + (lamp.IsOn() ? "Ligada" : "Desligada"));
    }
}
