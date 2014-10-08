using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02C
{
    class Program
    {
        string HorizontalLine { get; set; }
        
        static void Main(string[] args)
        {
            /*
             * Metoden ska instansiera objekt av klassen AlarmClock och testa konstruktorerna, egenskaperna och 
                metoderna.
             */
        }

        private static void Run(AlarmClock ac, int minutes)
        {
            /*
             * Privat statisk metod som har två parametrar. Den första parametern är en referens till AlarmClock-objekt. 
             * Den andra parametern är antalet minuter som AlarmClock-objektet ska gå (Vilken lämpligen görs genom att 
             * låta ett AlarmClock-objekt göra upprepade anrop av metoder TickTock()).
             */


        }

        private static void ViewErrorMessage(string message)
        {
            /* 
             * Privat statisk metoden som tar ett felmeddelande som argument och presenterar det.
             */
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
            
        }

        private static void ViewTestHeader(string header)
        {
            /*
             * Privat statisk metod som tar en sträng som argument och presenterar strängen.
             */
            Console.WriteLine(header);
        }

    }
}
