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
            int[] notas = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 2 };
            string[] pessoas = new string[] { "Joao", "Maria", "Renan", "Carlos", "Pedro", "Carol", "Bruna", "Suelen", "Neide", "Magda" };
            decimal media;
            
            //SETANDO AS VARIAVEIS
            media = 0;

            //EXECUTANDO CALCULOS
            media = ((notas[0]+notas[1]+notas[2]+notas[3]+notas[4]+notas[5]+notas[6]+notas[7]+notas[8]+notas[9]) / 10);
            
            //IMPRIMINDO AS VARIAVEIS
            Console.WriteLine("A nota do " + pessoas[0] + " é " + notas[0]);
            Console.WriteLine("A nota do " + pessoas[1] + " é " + notas[1]);
            Console.WriteLine("A nota do " + pessoas[2] + " é " + notas[2]);
            Console.WriteLine("A nota do " + pessoas[3] + " é " + notas[3]);
            Console.WriteLine("A nota do " + pessoas[4] + " é " + notas[4]);
            Console.WriteLine("A nota do " + pessoas[5] + " é " + notas[5]);
            Console.WriteLine("A nota do " + pessoas[6] + " é " + notas[6]);
            Console.WriteLine("A nota do " + pessoas[7] + " é " + notas[7]);
            Console.WriteLine("A nota do " + pessoas[8] + " é " + notas[8]);
            Console.WriteLine("A nota do " + pessoas[9] + " é " + notas[9]);
            Console.WriteLine("");       
            Console.WriteLine("A media das notas entre os alunos é " + media );
            
            
            Console.ReadKey();
        }
    }
} //Fim do programa