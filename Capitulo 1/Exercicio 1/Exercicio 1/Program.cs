using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //CONFIGURAÇÃO DAS CORES DO CONSOLE
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            
            //PROGRAMAÇÃO DO CONSOLE, PARTE VISUAL
            Console.SetWindowSize(50, 30);
            Console.Title = ("Supervisório em Visual C#");
        
            //DESCRIÇAO
            Console.WriteLine("Ola, Bom dia, Meu nome é Renan");          //Escrita apresentação do meu nome
            Console.WriteLine("Estamos em Cordeirópolis dia 16/04/2015"); //Escrita da cidade e dia
            Console.ReadKey();                                            // Pausa até que pressionado uma tecla
        }
    }
}
