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
            string nome;
            int idade;
            int peso;
            
            //SETANDO AS VARIAVEIS
            nome = "Renan Bacochina";
            idade = 24;
            peso = 93;
            
            //IMPRIMINDO AS VARIAVEIS
            Console.WriteLine("Meu nome é " + nome);              //Impressao do nome
            Console.WriteLine("Meu peso é " + peso + " Kg");        //Impressão do peso
            Console.WriteLine("Minha idade é " + idade + " anos");  //Impressão da idade
            Console.ReadKey();                                    //Aguardando até que aperta uma tecla
        }
    }
} //Fim do programa