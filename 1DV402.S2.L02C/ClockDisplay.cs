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

    // Properties
        private string HourDisplay
        {
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
            get
            {
                return String.Format("{0}:{1}", HourDisplay, MinuteDisplay);
            }
            set
            {
                // Validate timeformat.
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

    // Constructors
        public ClockDisplay() : this(0, 0)
        {

        }

        public ClockDisplay(int hour, int minute)
        {
            // Initialize object with values

            _hourDisplay = new NumberDisplay(23);
            _minuteDisplay = new NumberDisplay(59);

            HourDisplay = hour.ToString();
            MinuteDisplay = minute.ToString();
        }

        public ClockDisplay(string time)
        {
            // Initialize object with values

            _hourDisplay = new NumberDisplay(23);
            _minuteDisplay = new NumberDisplay(59);

            Time = time;
        }

    // Methods
        public void Increment()
        {
            // Check if its time to increase hour by 1.
            if (MinuteDisplay == "59")
            {
                // Increase or reset hour
                HourDisplay = (HourDisplay == "23") ? "0" : (int.Parse(HourDisplay) + 1).ToString();

                MinuteDisplay = "0";
            }
            else
            {
                // Increase minute by 1.
                MinuteDisplay = (int.Parse(MinuteDisplay) + 1).ToString();
            }
        }

    // Override methods 
        public override bool Equals(object obj)
        {
            // Is null test
            ClockDisplay testObj = obj as ClockDisplay;

            if (testObj == null)
            {
                return false;
            }

            // Check if the tested object has the same values as this object
            return (base.Equals(testObj) &&
                    testObj.MinuteDisplay == this.MinuteDisplay &&
                    testObj.HourDisplay == this.HourDisplay);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return Time;
        }

    // Override operators
        static public bool operator ==(ClockDisplay A, ClockDisplay B)
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
            if (A.Time == B.Time)
            {
                return true;
            }
            return false;
        }

        static public bool operator !=(ClockDisplay A, ClockDisplay B)
        {
            return !(A == B);
        }
    }
}
