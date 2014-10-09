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

    // Properties
        public string[] AlarmTimes 
        {
            get
            {
                // Declare array to return.
                string[] returnArray = new string[_alarmTimes.Length];

                // Loop through _alarmTimes and assign return array with string values of alarmtimes.
                for (int i = 0; i < _alarmTimes.Length; i++)
                {
                    if (_alarmTimes[i] != null)
                    {
                        returnArray[i] = _alarmTimes[i].ToString();
                    }
                }

                return returnArray;
            }
            set
            {
                // Resize array
                Array.Resize<ClockDisplay>(ref _alarmTimes, value.Length);

                // Clear old array
                Array.Clear(_alarmTimes, 0, _alarmTimes.Length);

                // Loop to build ClockDisplay objects
                for (int i = 0; i < value.Length; i++)
                {
                    _alarmTimes[i] = new ClockDisplay(value[i]);
                }
            }
        }

        public string Time
        {
            get
            {
                return _time.Time;
            }
            set
            {
                _time.Time = value;
            }
        }


    // Constructors
        public AlarmClock() : this(0, 0)
        {

        }

        public AlarmClock(int hour, int minute) : this(hour, minute, 0, 0)
        {

        }

        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            // Initiate object values
            _alarmTimes = new ClockDisplay[0];
            _time = new ClockDisplay();

            Time = String.Format("{0}:{1:00}", hour, minute);
            AlarmTimes = new string[] { String.Format("{0}:{1:00}", alarmHour, alarmMinute) };
        }

        public AlarmClock(string time, params string[] alarmTimes)
        {
            // Initiate object values
            _alarmTimes = new ClockDisplay[0];
            _time = new ClockDisplay();

            Time = time;
            AlarmTimes = alarmTimes;
        }

    // Methods
        public bool TickTock()
        {
            // Increase time by one minute
            _time.Increment();

            // Check if its time for an alarm
            if (AlarmTimes != null)
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

    // Override methods
        public override bool Equals(object obj)
        {
            AlarmClock testObj = obj as AlarmClock;

            if (testObj == null)
            {
                return false;
            }
            
            // Check if the tested object has the same _time and _alarmTimes values as this object
            return (base.Equals(testObj) && 
                    testObj.Time == this.Time &&
                    testObj.AlarmTimes.ToString() == this.AlarmTimes.ToString());
        }

        public override int GetHashCode()
        {
            // Get hashcode for current time with alarms
            return int.Parse(this.ToString()).GetHashCode();
        }

        public override string ToString()
        {
            // Returns the current time with (alarmtimes)
            return String.Format("{0} ({1})", Time, String.Join(", ", AlarmTimes));
        }

    // Override operators
        static public bool operator ==(AlarmClock A, AlarmClock B)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(A, B))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if((object) A == null || (object) B == null)
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

        static public bool operator !=(AlarmClock A, AlarmClock B)
        {
            return !(A == B);
        }
    }
}
