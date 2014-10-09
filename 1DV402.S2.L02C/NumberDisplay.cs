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

    // Properties
        public int MaxNumber
        {
            get
            {
                return _maxNumber;
            }
            set
            {
                // Validate potential _maxNumber value
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format("Det högsta värdet '{0}' måste vara högre än 0.", value));
                }
                else
                {
                    _maxNumber = value;
                }
            }
        }

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                // Validate potential _number value
                if (value < 0 || value > MaxNumber)
                {
                    throw new ArgumentException(String.Format("Värdet {0} Ligger inte inom intervallen 0 och {1}", value, MaxNumber));
                }
                else
                {
                    _number = value;
                }
            }
        }

    // Constructors
        public NumberDisplay(int maxNumber) : this(maxNumber,0)
        {

        }

        public  NumberDisplay(int maxNumber, int number)
        {
            // Initiate object values
            MaxNumber = maxNumber;
            Number = number;
        }

    // Methods
        public void Increment()
        {
            // Increase Number until MaxNumer is reached, then reset to 0
            Number = (Number + 1 >= MaxNumber ? 0 : Number + 1);
        }

    // Override methods
        public override bool Equals(object obj)
        {
            NumberDisplay testObj = obj as NumberDisplay;

            if (testObj == null)
            {
                return false;
            }

            // Check if the tested object has the same _time and _alarmTimes values as this object
            return (base.Equals(testObj) &&
                    testObj.MaxNumber == this.MaxNumber &&
                    testObj.Number == this.Number);
        }

        public override int GetHashCode()
        {
            // Return properties of this object as generated hash. (Number and MaxNumber)
            return (this.ToString("G") + MaxNumber.ToString()).GetHashCode();
        }

        public override string ToString()
        {
            // Return Number property as string
            return Number.ToString();
        }

        public string ToString(string format)
        {
            // Return Number property as string in desired format.

            if (format == "0" || format == "G" || format == "00" && Number > 10)
            {
                return String.Format("{0}", Number);
            }
            else if (format == "00")
            {
                return String.Format("{0:00}", Number); 
            }
            else 
            {
                throw new FormatException();
            }
        }

    // Override operators
        static public bool operator ==(NumberDisplay A, NumberDisplay B)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(A, B))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if ((object)A == null || (object)B == null)
            {
                return false;
            }

            // Return true if the fields match
            if (A.Number == B.Number)
            {
                return true;
            }
            return false;
        }

        static public bool operator !=(NumberDisplay A, NumberDisplay B)
        {
            return !(A == B);
        }
    }
}
