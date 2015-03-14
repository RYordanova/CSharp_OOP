using System;
using System.Text.RegularExpressions;

namespace MobilePhone
{
    public class Call
    {
        public DateTime DateTime
        {
            get;
            private set;
        }

        public string DialledPhone
        {
            get;
            private set;
        }
        public TimeSpan Duration
        {
            get;
            private set;
        }

        public Call(string dialledPhone, TimeSpan duration)
            : this(dialledPhone, duration, DateTime.Now)
        {
        }

        public Call(string dialledPhone, TimeSpan duration, DateTime dateTime)
        {
            if (String.IsNullOrEmpty(dialledPhone) || !Regex.IsMatch(dialledPhone, @"^(\+\d{12})|(\d{10})$"))
            {
                throw new ArgumentException("Invalid phone number.");
            }
            this.DialledPhone = dialledPhone;

            if (duration == null || duration.Seconds <= 0)
            {
                throw new ArgumentException("Duration is invalid.");
            }
            this.Duration = duration;

            if (dateTime == null)
            {
                throw new ArgumentNullException("DateTime is null");
            }
            this.DateTime = dateTime;
        }
    }
}
