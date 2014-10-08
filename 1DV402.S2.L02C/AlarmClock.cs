using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02C
{
    class AlarmClock
    {
        private string[] _alarmTimes;
        private string _time;

        public string[] AlarmTimes 
        {
            /*
             * Publik egenskap som av typen string[] som kapslar in fältet _alarmTimes som är av typen ClockDisplay[].
             *  get-metoden ska ge en array innehållande alarmtider i form av strängar. Egenskapen konverterar alltså 
                referenser till ClockDisplay-objekt till strängar. Vid ändring av en sträng i arrayen ska inte 
                underliggande ClockDisplay-objekt ändras.
             * Set-metoden ska konvertera varje alarmtid, i form av en sträng, till ett ClockDisplay-objekt
             */
            get
            {
                // Convert here...
                return _alarmTimes;
            }
            set
            {
                // Convert here...
                _alarmTimes = value;
            }
        }


        public string Time
        {
            /*
             * Publik egenskap av typen string som kapslar in fältet _time som är av typen ClockDisplay.
             */
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }
        }


        /*
         * Konstruktorerna, som är fyra till antalet, ska se till att ett AlarmClock-objekt blir korrekt initierat. Det 
            innebär att fälten ska initieras med lämpliga värden
        */ 

        AlarmClock() : this(0, 0)
        {
            /*
             * ska initiera fälten så att de refererar till objekt. Ingen tilldelning 
                får ske i konstruktorns kropp, som måste vara tom. Denna konstruktor måste därför anropa den 
                konstruktor i klassen som har två parametrar.
             */
            
        }
        AlarmClock(int hour, int minute) : this(0, 0, 0, 0)
        {
            /*
             * Med konstruktorn AlarmClock(int hour, int minute) ska ett objekt kunna initieras så att 
                väckarklockan ställs på den tid som parametrarna för timme respektive minut anger. Ingen tilldelning 
                får ske i konstruktorns kropp, som måste vara tom. Denna konstruktor måste därför anropa den 
                konstruktor i klassen som har fyra parametrar.
             */
        }
        AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            /*
             * Med konstruktorn AlarmClock(int hour, int minute , int alarmHour, int alarmMinute)
                ska ett objekt kunna initieras så att väckarklockan ställs på den tid och alarmtid som parametrarna 
                anger. Detta är en konstruktor som får innehålla kod som leder till att fält i klassen tilldelas värden.
             */

            Time = String.Format("{0}.{1}", hour, minute);

            // TODO set alarmtime
        }
        AlarmClock(string time, params string[] alarmTimes)
        {
            /*
             * Med konstruktorn AlarmClock(string time, params string[] alarmTimes) ska ett objekt kunna 
                initieras så att väckarklockan ställs på den tid och ett godtyckligt antal, minst en dock, alarmtider som 
                parametrarna anger. Detta är en konstruktor som får innehålla kod som leder till att fält i klassen 
                tilldelas värden.
             */

            Time = time;

            // TODO set alarmtime
        }

        public override bool Equals(object obj)
        {
            /*
             * Överskuggar metoden Equals() i basklassen Object och returnerar ett värde som anger om den
                anropande instansen är lika med ett angivet objekt beträffande textbeskrivningarna innehållande 
                aktuell tid samt alarmtider. 
             */

            

            return false;
        }

        public override int GetHashCode()
        {
            /*
             * Överskuggar metoden GetHashCode() i basklassen Object och returnerar ett heltal av typen int som 
                beskriver det anropande objektet. Lämpligen returnerar metoden hashkoden för textbeskrivningen, 
                d.v.s. det som metoden ToString() returnerar.
             */
            int _returnValue;

            int.TryParse(this.ToString(), out _returnValue); // No catch, may throw exception.
            return _returnValue;
        }

        public bool TickTock()
        {
            /*
             * Publik metod som anropas för att få klockan att gå en minut. Om den nya tiden överensstämmer med 
                någon av alarmtiderna ska metoden returnera true, annars false. Inga utskrifter till konsolfönstret får 
                göras av metoden.
             */

            foreach (string alarmTime in AlarmTimes)
            {
                if (alarmTime == Time)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            /*
             * Publik metod som har som uppgift att returnera en sträng representerande värdet av en instans av 
                klassen AlarmClock. Strängen ska innehålla aktuell tid samt alarmtiderna inom parenteser. Inga 
                utskrifter till konsolfönstret får göras av metoden.
             */


            return String.Format("{0} ({1})", Time, String.Join(",", AlarmTimes));
        }

        static public bool operator ==(AlarmClock A, AlarmClock B) // Static?
        {
            if(A.Equals(B))
            {
                return true;
            }
            return false;
        }

        static public bool operator !=(AlarmClock A, AlarmClock B) // Static?
        {
            if (!A.Equals(B))
            {
                return true;
            }
            return false;
        }
    }
}
