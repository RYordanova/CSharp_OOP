using System;

namespace MobilePhone
{
    public class Battery
    {
        public BatteryType Model
        {
            get;
            private set;
        }
        public int HoursIdle
        {
            get;
            private set;
        }
        public int HoursTalk
        {
            get;
            private set;
        }

        public Battery(BatteryType model = BatteryType.LiIon, int hoursIdle = 10, int hoursTalk = 0)
        {
            if (!Enum.IsDefined(typeof(BatteryType), model))
            {
                throw new ArgumentException("Invalid battery type");
            }
            this.Model = model;

            if (hoursIdle <= 0)
            {
                throw new ArgumentException("Negative or zero hours idle.");
            }
            this.HoursIdle = hoursIdle;

            if (hoursTalk < 0)
            {
                throw new ArgumentException("Negative hours talk.");
            }
            this.HoursTalk = hoursTalk;
        }
    }
}
