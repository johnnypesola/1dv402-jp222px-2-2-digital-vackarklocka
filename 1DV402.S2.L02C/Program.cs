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
            string testAlarmTime;
            string testAlarmGoOff;
            int testAlarmDuration;
            
        // Test 1
            AlarmClock aC1 = new AlarmClock();
            ViewTestHeader("Test 1.\nTest av standardkonstruktorn.");
            Console.WriteLine(String.Format("{0,6} ({1})", aC1.Time, aC1.AlarmTimes[0])); 

        // Test 2
            AlarmClock aC2 = new AlarmClock(9, 42);
            ViewTestHeader("Test 2.\nTest av konstruktorn med två parametrar.");
            Console.WriteLine(String.Format("{0,6} ({1})", aC2.Time, aC2.AlarmTimes[0])); 

        // Test 3
            AlarmClock aC3 = new AlarmClock(13, 24, 7, 35);
            ViewTestHeader("Test 3.\nTest av konstruktorn med fyra parametrar.");
            Console.WriteLine(String.Format("{0,6} ({1})", aC3.Time, aC3.AlarmTimes[0]));

        // Test 4
            AlarmClock aC4 = new AlarmClock("6:30", "3:40", "22:03", "16:00", "19:59");
            ViewTestHeader("Test 4.\nTest av konstruktorn med minst två parametrar av typen string. (\"6:30\", \"3:40\", \"22:03\", \"16:00\", \"19:59\")");
            Console.WriteLine(String.Format("{0,6} ({1}, {2}, {3}, {4})", aC4.Time, aC4.AlarmTimes[0], aC4.AlarmTimes[1], aC4.AlarmTimes[2], aC4.AlarmTimes[3]));

        // Test 5
            testAlarmTime = "23:58";
            testAlarmDuration = 13;
            aC1.Time = testAlarmTime;

            ViewTestHeader(String.Format("Test 5.\nStäller befintligt AlarmClock-objekt till {0} och låter den gå {1} minuter", testAlarmTime, testAlarmDuration));

            // Loop time
            for (int i = 0; i <= testAlarmDuration; i++)
            {
                aC1.TickTock();
                Console.WriteLine(String.Format("{0,10} ({1})", aC1.Time, aC1.AlarmTimes[0]));
            }

        // Test 6
            testAlarmTime = "6:12";
            testAlarmGoOff = "6:15";
            testAlarmDuration = 6;
            aC1.Time = testAlarmTime;
            aC1.AlarmTimes = new string[] { testAlarmGoOff };

            ViewTestHeader(String.Format("Test 6.\nStäller befintligt AlarmClock-objekt till {0} och låter den gå {1} minuter", testAlarmTime, testAlarmDuration));
            
            // Loop time
            for (int i = 0; i <= testAlarmDuration; i++)
            {
                if(aC1.TickTock())
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(String.Format("{0,2}{1,8} ({2}) {3}", "♫", aC1.Time, aC1.AlarmTimes[0], " RISE AND SHINE! "));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(String.Format("{0,10} ({1})", aC1.Time, aC1.AlarmTimes[0]));
                }
                
            }

        // Test 7
            ViewTestHeader("Test 7.\nTestar egenskaperna så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.");

            try { aC1.Time = "42:12"; } 
            catch (Exception e){ViewErrorMessage(e.Message); }

            try { aC1.AlarmTimes = new string[] { "6:yu44" }; }
            catch (Exception e) { ViewErrorMessage(e.Message); }

        // Test 8
            ViewTestHeader("Test 8.\nTestar konstruktorer så att undantag kastas då tid och alarmtider tilldelas felaktiga värden.");

            try { new AlarmClock("det här funkar inte"); }
            catch (Exception e) { ViewErrorMessage(e.Message); }

            try { new AlarmClock(33, 44); }
            catch (Exception e) { ViewErrorMessage(e.Message); }

            try { new AlarmClock(5, 666); }
            catch (Exception e) { ViewErrorMessage(e.Message); }

            try { new AlarmClock(7, 8, 9, 100); }
            catch (Exception e) { ViewErrorMessage(e.Message); }

            try { new AlarmClock("12:20", "73:12", "99:42", "63:21"); }
            catch (Exception e) { ViewErrorMessage(e.Message); }

        }

        private static void Run(AlarmClock ac, int minutes)
        {
            /*
             * Privat statisk metod som har två parametrar. Den första parametern är en referens till AlarmClock-objekt. 
             * Den andra parametern är antalet minuter som AlarmClock-objektet ska gå (Vilken lämpligen görs genom att 
             * låta ett AlarmClock-objekt göra upprepade anrop av metoder TickTock()).
             */

            ac.TickTock();

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

            Console.WriteLine("\n═══════════════════════════════════════════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(header);
            Console.WriteLine();
            Console.ResetColor();
        }

    }
}
