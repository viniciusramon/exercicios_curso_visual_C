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

            //DECLARAÇÃO DAS VARIVEIS
            string name;
            double idade;
            int peso;
            double imc = 0;
        
         
            
            //IMPRIMINDO AS VARIAVEIS
            Console.WriteLine("Bom dia, seja bem vindo ao aplicativo de calculo de IMC... Por favor insira os seus dados solicitados abaixo:");
            Console.WriteLine("");
            Console.Write("Digite seu nome: ");
            name = Console.ReadLine();
            Console.Write("Digita a sua altura: ");
            idade = Convert.ToDouble (Console.ReadLine());
            Console.Write("Digite seu peso: ");
            peso = Convert.ToInt16(Console.ReadLine());
        

            //EXECUTANDO OS CALCULOS
            imc = (peso / (idade * idade))*10000;

            Console.WriteLine("O seu IMC é " +imc);
            Console.ReadKey();
        }
    }
} //Fim do programa
