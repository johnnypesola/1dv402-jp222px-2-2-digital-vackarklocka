using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02C
{
    class NumberDisplay
    {
        private int _maxNumber;
        private  int _number;

        [Description("The Maximum number")] 
        public int MaxNumber
        {
            /*
             * Publik egenskap, som kapslar in det privata fältet _maxNumber. set-metoden måste validera att värdet 
                som ska tilldelas _maxNumber är större än 0. Är värdet inte det ska ett undantag av typen ArgumentException kastas.
             */
            get
            {
                return _maxNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _maxNumber = value;
                }
            }
        }

        [Description("The number")] 
        public int Number
        {
            /*
             * Publik egenskap, som kapslar in det privata fältet _number. set-metoden måste validera att värdet som 
                ska tilldelas _number är i det slutna intervallet mellan 0 och maxvärdet. Är värdet inte i intervallet ska 
                ett undantag av typen ArgumentException kastas.
             */
            get
            {
                return _number;
            }
            set
            {
                if (value < 0 || value > MaxNumber)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _number = value;
                }
            }
        }

        /*
         * Konstruktorerna, som är två till antalet, ska se till att ett NumberDisplay-objekt blir korrekt initierat. 
            Det innebär att fälten ska initieras med lämpliga värden 
         */
        NumberDisplay(int maxNumber) : this(1,0)
        {
            /*
             * Konstruktorn NumberDisplay(int maxNumber) ska se till att fälten initieras så de refererar till 
                NumberDisplay-obejkt men ingen tilldelning får ske i konstruktorns kropp, som måste vara tom. 
                Denna konstruktor måste därför anropa den konstruktor i klassen som har två parametrar.
             */

        }
        NumberDisplay(int maxNumber, int number)
        {
            /*
             * Med konstruktorn NumberDisplay(int maxNumber, int number) ska ett objekt initieras så att 
                objektets fält tilldelas värdena parametrarna har. Detta är den enda av konstruktorerna som får 
                innehålla kod som tilldelar fält i klassen värden.
             */
            MaxNumber = maxNumber;
            Number = number;
        }

        public override bool Equals(object obj)
        {
            /*
             * Överskuggar metoden Equals() i basklassen Object och returnerar ett värde som anger om den
                anropande instansen är lika med ett angivet objekt beträffande fälten _maxNumber och _number. 
             */



            return false;
        }

        public override int GetHashCode()
        {
            /*
             * Överskuggar metoden GetHashCode() i basklassen Object och returnerar ett heltal av typen int som 
                beskriver det anropande objektet. Lämpligen returnerar metoden hashkoden för t.ex. textbeskrivningen 
                av fälten
             */

            // Get DescriptionAttribute of MaxNumber property in this class type. (To generate hash with)
            object maxNumberAttribute = typeof(NumberDisplay).GetProperty("MaxNumber").GetCustomAttributes(typeof(DescriptionAttribute), true)[0];

            // Get text for Descriptionatritube
            string MaxNumberDescriptionText = ((DescriptionAttribute)maxNumberAttribute).Description;

            // Return hashcode
            return MaxNumberDescriptionText.GetHashCode();
        }

        public void Increment()
        {
            /*
             * Publik metod som anropas för att få NumberDisplay-objektet att öka numret med 1. Då värdet fältet 
                _number har ska passera värdet fältet _maxNumber har ska fältet _number tilldelas värdet 0. Inga 
                utskrifter till konsolfönstret får göras av metoden
             */

            Number = (Number + 1 >= MaxNumber ? 0 : Number + 1);
        }


        /*
            ToString() ska överlagras, d.v.s. det ska finnas två metoder med samma namn men med olika 
            parameterlistor.
         */ 
        public override string ToString()
        {
            /*
             * Den publika metoden ToString() har som uppgift att returnera en sträng representerande värdet av en 
                instans av klassen NumberDisplay. Strängen ska innehålla numret, utan att nummer mindre än tio 
                inleds med 0. Inga utskrifter till konsolfönstret får göras av metoden.
             */

            return String.Format("{0}", Number);
        }

        public string ToString(string format)
        {
            /*
             * Den publika metoden ToString(string format) har som uppgift att returnera en sträng 
                representerande värdet av en instans av klassen NumberDisplay. Formatsträngen ska bestämma om 
                nummer mindre än tio ska inledas med 0. 
                Är formatsträngen ”0” eller ”G” ska numret inte inledas med 0. Är formatsträngen ”00” ska numret 
                inleda med 0 om numret är mindre än tio. Alla övriga värden på formatsträngen ska leda till att ett 
                undantag av typen FormatException kastas.
             * 
             */

            if (format == "0" || format == "G" || format == "00" && int.Parse(format) < 10)
            {
                return String.Format("0{0}", Number);
            }
            else if (format == "00")
            {
                return String.Format("{0}", Number);
            }
            else 
            {
                throw new FormatException();
            }
        }

        static public bool operator ==(NumberDisplay A, NumberDisplay B) // Static?
        {
            if (A.Equals(B))
            {
                return true;
            }
            return false;
        }

        static public bool operator !=(NumberDisplay A, NumberDisplay B) // Static?
        {
            if (!A.Equals(B))
            {
                return true;
            }
            return false;
        }

    }
}
