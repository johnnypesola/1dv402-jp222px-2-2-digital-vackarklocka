using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _1DV402.S2.L02C
{
    class ClockDisplay
    {
        private NumberDisplay _hourDisplay;
        private NumberDisplay _minuteDisplay;

        private string HourDisplay
        {
            /*
             * Privat fält som i innehåller referens till ett NumberDisplay-objekt som ansvarar för timmarna. Kapslas 
                delvis in av egenskapen Time, som är av typen string.
             */
            get
            {
                return _hourDisplay.Number.ToString();
            }
            set
            {
                _hourDisplay.Number = int.Parse(value);
            }
        }

        private string MinuteDisplay
        {
            /*
             * Privat fält som i innehåller referens till ett NumberDisplay-objekt som ansvarar för minuterna. 
                Kapslas delvis in av egenskapen Time, som är av typen string.
             */
            get
            {
                // Add leading zero for string representation.
                return _minuteDisplay.Number.ToString("00");
            }
            set
            {
                // Note: Leading zero disappears in int conversion.
                _minuteDisplay.Number = int.Parse(value);
            }
        }

        public string Time 
        {
            /*
             * Publik egenskap av typen string, som kapslar in de privata fälten _hourDisplay och 
                _minuteDisplay. Strängens format ska vara HH:mm, d.v.s. timmar och minuter åtskilda av ett kolon.
                set-metoden ska kasta ett undantag av typen FormatException om strängen som tilldelas egenskapen 
                inte har rätt format. Använd det reguljära uttrycket "^(([0-1]?[0-9])|([2][0-3])):([0-5][0-
                9])$" för att validera tiden. När väl tiden är validerad delas den enkelt upp i timmar och minuter med 
                hjälp av metoden String.Split().
             */
            get
            {
                return String.Format("{0}:{1}", HourDisplay, MinuteDisplay);
            }
            set
            {
                // Try match
                Match match = Regex.Match(value, "^(([0-1]?[0-9])|([2][0-3])):([0-5][0-9])$");

                // Check if there was match
                if (match.Success) 
                {
                    string[] hourAndMinute = value.Split(':');

                    HourDisplay = hourAndMinute[0];
                    MinuteDisplay = hourAndMinute[1];
                }
                else
                {
                    throw new FormatException(String.Format("Strängen '{0}' kan inte tolkas som en tid på formatet HH:mm.", value));
                }
            }
        }

        /*
         * Konstruktorerna, som är tre till antalet, ska se till att ett ClockDisplay-objekt blir korrekt initierat. 
            Det innebär att fälten ska initieras med lämpliga värden.
         */

        public ClockDisplay() : this(0, 0)
        {
            /*
             * Standardkonstruktorn ClockDisplay() ska se till att fälten initieras så de refererar till 
                NumberDisplay-objekt men ingen tilldelning får ske i konstruktorns kropp, som måste vara tom. 
                Denna konstruktor måste därför anropa den konstruktor i klassen som har två parametrar
             */
        }
        public ClockDisplay(int hour, int minute)
        {
            /*
             * Med konstruktorn ClockDisplay(int hour, int minute) ska ett objekt initieras så att objektet 
                ställs på den tid som parametrarna anger. Detta är den ena av konstruktorerna som får innehålla kod 
                som leder till att fält i klassen tilldelas värden.
             */

            _hourDisplay = new NumberDisplay(23);
            _minuteDisplay = new NumberDisplay(59);

            HourDisplay = hour.ToString();
            MinuteDisplay = minute.ToString();
        }
        public ClockDisplay(string time)
        {
            /*
             * Med konstruktorn ClockDisplay(string time) ska ett objekt initieras så att objektet ställs på den 
                tid som parametern, på formatet HH:mm, anger. Detta är den ena av konstruktorerna som får innehålla 
                kod som leder till att fält i klassen tilldelas värden.
             */

            _hourDisplay = new NumberDisplay(23);
            _minuteDisplay = new NumberDisplay(59);

            Time = time;
        }

        public override bool Equals(object obj)
        {
            /*
             * Överskuggar metoden Equals() i basklassen Object och returnerar ett värde som anger om den
                anropande instansen är lika med ett angivet objekt beträffande fälten _hourDisplay och 
                _minuteDisplay. 
             */

            ClockDisplay testObj = obj as ClockDisplay;

            if (testObj == null)
            {
                return false;
            }

            // Check if the tested object has the same _time and _alarmTimes values as this object
            return (this.Equals(testObj) && testObj.HourDisplay == this.HourDisplay && testObj.MinuteDisplay == this.MinuteDisplay);

        }

        public override int GetHashCode()
        {
            /*
                * Överskuggar metoden GetHashCode() i basklassen Object och returnerar ett heltal av typen int som 
                beskriver det anropande objektet. Lämpligen returnerar metoden hashkoden för textbeskrivningen, 
                d.v.s. det som metoden ToString() returnerar.
            */

            return ToString().GetHashCode();
        }

        public void Increment()
        {
            /*
             * Publik metod som anropas för att få ClockDisplay-objektet att gå en minut. Metoden ansvarar för att 
                öka minuternas värde med 1. Då värdet för minuterna blir 0 ökas lämpligen timmarnas värde med 1. 
                Inga utskrifter till konsolfönstret får göras av metoden.
             */

            // Check if its time to increase hour.
            if(MinuteDisplay == "59")
            {
                // Increase or reset hour
                HourDisplay = (HourDisplay == "23") ? "0" : (int.Parse(HourDisplay) + 1).ToString();

                MinuteDisplay = "0";
            }
            else
            {
                // Increase minute by one 
                MinuteDisplay = (int.Parse(MinuteDisplay) + 1).ToString();
            }
        }

        public override string ToString()
        {
            /*
             * Publik metod som har som uppgift att returnera en sträng representerande värdet av en instans av 
                klassen ClockDisplay. Strängen ska innehålla tiden på formatet HH:mm. Inga utskrifter till 
                konsolfönstret får göras av metoden.
             */

            return Time;
        }

        static public bool operator ==(ClockDisplay A, ClockDisplay B) // Static?
        {
            if (A.Equals(B))
            {
                return true;
            }
            return false;
        }

        static public bool operator !=(ClockDisplay A, ClockDisplay B) // Static?
        {
            if (!A.Equals(B))
            {
                return true;
            }
            return false;
        }
    }
}
