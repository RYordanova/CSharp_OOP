using System;
using System.Collections.Generic;
using System.Linq;
namespace MobilePhone
{
    public class GSM
    {
        private static readonly GSM iPhone4S = new GSM("IPhone4S", "APPLE", 1000.0m, "APPLE",
            new Battery(BatteryType.NiCd, 300, 25), new Display(16, 20000));

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        public string Model
        {
            get;
            private set;
        }
        public string Manifacturer
        {
            get;
            private set;
        }
        public decimal Price
        {
            get;
            private set;
        }
        public string Owner
        {
            get;
            private set;
        }
        public Battery Battery
        {
            get;
            private set;
        }
        public Display Display
        {
            get;
            private set;
        }
        public List<Call> CallHistory;

        public GSM(string model, string manifacturer, decimal price = 0.0m, string owner = "Me")
            : this(model, manifacturer, price, owner, new Battery())
        {
        }
        public GSM(string model, string manifacturer, decimal price, string owner, Battery battery)
            : this(model, manifacturer, price, owner, battery, new Display())
        {
        }
        public GSM(string model, string manifacturer, decimal price, string owner, Battery battery, Display display)
        {
            if (String.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException("Model is null.");
            }
            this.Model = model;
            if (String.IsNullOrWhiteSpace(manifacturer))
            {
                throw new ArgumentNullException("Manifacturer is null.");
            }
            this.Manifacturer = manifacturer;
            if (price < 0)
            {
                throw new ArgumentException("Negative price.");
            }
            this.Price = price;
            if (String.IsNullOrWhiteSpace(owner))
            {
                throw new ArgumentNullException("Owner is null or white space.");
            }
            this.Owner = owner;
            if (battery == null)
            {
                throw new ArgumentNullException("Battery is null.");
            }
            this.Battery = battery;
            if (display == null)
            {
                throw new ArgumentNullException("Display is null.");
            }
            this.Display = display;
            this.CallHistory = new List<Call>();
        }

        public override string ToString()
        {
            return String.Format("Model: {0}{8}Manifacturer: {1}{8}Price: {2}{8}Battery Model: {3}{8}Battery Hours idle: {4}{8}Battery Hours talk: {5}{8}Display Size: {6}{8}Display Number of colors: {7}{8}",
                this.Model,
                this.Manifacturer,
                this.Price,
                this.Battery.Model,
                this.Battery.HoursIdle,
                this.Battery.HoursTalk,
                this.Display.Size,
                this.Display.NumberOfColors,
                Environment.NewLine);
        }

        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            this.CallHistory.Remove(call);
        }

        public decimal GetTotalPriceForCalls(decimal pricePerminute)
        {
            TimeSpan totalDuration = this.CallHistory.Select(call => call.Duration).Aggregate((result, x) => result.Add(x));
            return (int)totalDuration.TotalMinutes * pricePerminute;
        }
    }
}
