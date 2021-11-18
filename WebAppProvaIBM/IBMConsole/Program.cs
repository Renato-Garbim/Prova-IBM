using IBMServices;
using System;



namespace IBMConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Informe um salário?");
            var name = Console.ReadLine();

            Console.WriteLine("Informe um ano?");
            var date = Console.ReadLine();

            var servico = new CalculadorInssService();
            var resultado = servico.CalcularDesconto(name, date);


            Console.WriteLine("Hello World!");
        }
    }
}
