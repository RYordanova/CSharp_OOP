using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    class GSMCallHistoryTest
    {
        public void Test()
        {
            Battery battery = new Battery(BatteryType.LiIon, 5, 6);
            Display display = new Display(16, 16000);
            GSM gsm = new GSM("Alcatel", "Alcatel", 100.0m, "Ivan", battery,display);

            DateTime now = DateTime.Now;
            Call firstCall = new Call("0888728362", new TimeSpan(0, 0, 38), now);
            Call secondCall = new Call("0888278362", new TimeSpan(0, 2, 38), now);
            Call thirdCall = new Call("0889728362", new TimeSpan(1, 3, 38), now);

            gsm.AddCall(firstCall);
            gsm.AddCall(secondCall);
            gsm.AddCall(thirdCall);

            for (int i = 0; i < gsm.CallHistory.Count; i++)
            {
                Console.WriteLine("{0}. Date and time: {1}{4}Dialled Phone: {2}{4}Duration: {3}", i+1,
                    gsm.CallHistory[i].DateTime, gsm.CallHistory[i].DialledPhone, gsm.CallHistory[i].Duration, Environment.NewLine);
            }

            Console.WriteLine();
            Console.WriteLine("Total price: {0}", gsm.GetTotalPriceForCalls(0.37m));

            gsm.DeleteCall(gsm.CallHistory.OrderBy(x => x.Duration).Last());

            Console.WriteLine("Total price after removing the longest call: {0}", gsm.GetTotalPriceForCalls(0.37m));

            gsm.CallHistory.Clear();

            for (int i = 0; i <gsm.CallHistory.Count; i++)
            {
                Console.WriteLine("{0}. Date and time: {1}{4}Dialled Phone: {2}{4}Duration: {3}", i + 1,
                    gsm.CallHistory[i].DateTime, gsm.CallHistory[i].DialledPhone, gsm.CallHistory[i].Duration, Environment.NewLine);
            }
        }
    }
}
