using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    class GSMTest
    {
        public void Test()
        {
            GSM[] arr = new GSM[] {
                new GSM("IPhone", "APPLE", 100.0m, "Peter", new Battery(BatteryType.NiMH, 30, 25), new Display(16, 2000)), 
                new GSM("Samsumg", "Samsung", 10000.0m, "Ivan", new Battery(BatteryType.NiCd, 300, 16), new Display(16, 200)), 
                new GSM("Alcatel", "Alcat", 200.0m, "Georgi", new Battery(BatteryType.LiIon, 400, 30), new Display(20, 3000))};

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
