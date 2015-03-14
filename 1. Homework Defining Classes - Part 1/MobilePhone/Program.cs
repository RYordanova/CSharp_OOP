using System;
using System.Threading.Tasks;
namespace MobilePhone
{
    class Program
    {
        static void Main(string[] args)
        {
            GSMTest test = new GSMTest();
            test.Test();
            GSMCallHistoryTest callHistoryTest = new GSMCallHistoryTest();
            callHistoryTest.Test();
        }
    }
}
