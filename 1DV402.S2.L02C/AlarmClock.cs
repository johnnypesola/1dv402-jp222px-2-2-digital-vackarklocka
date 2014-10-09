using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02C
{
    class AlarmClock
    {
        private ClockDisplay[] _alarmTimes;
        private ClockDisplay _time;

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
                // Declare array to return.
                string[] returnArray = new string[_alarmTimes.Length];

                // Loop through _alarmTimes and assign return array with string values of alarmtimes.
                for (int i = 0; i < _alarmTimes.Length; i++)
                {
                    returnArray[i] = _alarmTimes[i].ToString();
                }

                return returnArray;
            }
            set
            {
                // Declare array of ClockDisplay:s with length of delared values
                ClockDisplay[] setArray = new ClockDisplay[value.Length];


                // Loop to build ClockDisplay objects
                for (int i = 0; i < value.Length; i++)
                {
                    setArray[i] = new ClockDisplay(value[i]);
                }

                // Set our new array filled with ClockDisplay objects.
                _alarmTimes = setArray;
            }
        }


        public string Time
        {
            /*
             * Publik egenskap av typen string som kapslar in fältet _time som är av typen ClockDisplay.
             */
            get
            {
                return _time.Time;
            }
            set
            {
                _time.Time = value;
            }
        }


        /*
         * Konstruktorerna, som är fyra till antalet, ska se till att ett AlarmClock-objekt blir korrekt initierat. Det 
            innebär att fälten ska initieras med lämpliga värden
        */ 

        public AlarmClock() : this(0, 0)
        {
            /*
             * ska initiera fälten så att de refererar till objekt. Ingen tilldelning 
                får ske i konstruktorns kropp, som måste vara tom. Denna konstruktor måste därför anropa den 
                konstruktor i klassen som har två parametrar.
             */
        }
        public AlarmClock(int hour, int minute) : this(hour, minute, 0, 0)
        {
            /*
             * Med konstruktorn AlarmClock(int hour, int minute) ska ett objekt kunna initieras så att 
                väckarklockan ställs på den tid som parametrarna för timme respektive minut anger. Ingen tilldelning 
                får ske i konstruktorns kropp, som måste vara tom. Denna konstruktor måste därför anropa den 
                konstruktor i klassen som har fyra parametrar.
             */
        }
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            /*
             * Med konstruktorn AlarmClock(int hour, int minute , int alarmHour, int alarmMinute)
                ska ett objekt kunna initieras så att väckarklockan ställs på den tid och alarmtid som parametrarna 
                anger. Detta är en konstruktor som får innehålla kod som leder till att fält i klassen tilldelas värden.
             */

            _alarmTimes = new ClockDisplay[0];
            _time = new ClockDisplay();

            Time = String.Format("{0}:{1:00}", hour, minute);
            AlarmTimes = new string[] { String.Format("{0}:{1:00}", alarmHour, alarmMinute) };
        }
        public AlarmClock(string time, params string[] alarmTimes)
        {
            /*
             * Med konstruktorn AlarmClock(string time, params string[] alarmTimes) ska ett objekt kunna 
                initieras så att väckarklockan ställs på den tid och ett godtyckligt antal, minst en dock, alarmtider som 
                parametrarna anger. Detta är en konstruktor som får innehålla kod som leder till att fält i klassen 
                tilldelas värden.
             */

            _alarmTimes = new ClockDisplay[0];
            _time = new ClockDisplay();

            Time = time;
            AlarmTimes = alarmTimes;
        }

        public override bool Equals(object obj)
        {
            /*
             * Överskuggar metoden Equals() i basklassen Object och returnerar ett värde som anger om den
                anropande instansen är lika med ett angivet objekt beträffande textbeskrivningarna innehållande 
                aktuell tid samt alarmtider. 
             */

            AlarmClock testObj = obj as AlarmClock;

            if (testObj == null)
            {
                return false;
            }
            
            // Check if the tested object has the same _time and _alarmTimes values as this object
            return (this.Equals(testObj) && testObj.Time == this.Time && testObj.AlarmTimes == this.AlarmTimes);
        }

        public override int GetHashCode()
        {
            /*
             * Överskuggar metoden GetHashCode() i basklassen Object och returnerar ett heltal av typen int som 
                beskriver det anropande objektet. Lämpligen returnerar metoden hashkoden för textbeskrivningen, 
                d.v.s. det som metoden ToString() returnerar.
             */

            return int.Parse(this.ToString()).GetHashCode();
        }

        public bool TickTock()
        {
            /*
             * Publik metod som anropas för att få klockan att gå en minut. Om den nya tiden överensstämmer med 
                någon av alarmtiderna ska metoden returnera true, annars false. Inga utskrifter till konsolfönstret får 
                göras av metoden.
             */

            // Increase time by one minute
            _time.Increment();

            // Check if its time for an alarm
            if(AlarmTimes != null)
            {
                foreach (string alarmTime in AlarmTimes)
                {
                    if (alarmTime == Time)
                    {
                        return true;
                    }
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


            return String.Format("{0} ({1})", Time, String.Join(", ", AlarmTimes));
        }

        static public bool operator ==(AlarmClock A, AlarmClock B) // Static?
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(A, B))
            {
                return true;
            }

            if((object) A == null || (object) B == null)
            {
                return false;
            }

            if (A.Time == B.Time)
            {
                return true;
            }
            return false;
        }

        static public bool operator !=(AlarmClock A, AlarmClock B) // Static?
        {
            if (A.Time != B.Time)
            {
                return true;
            }
            return false;
        }
    }
}
