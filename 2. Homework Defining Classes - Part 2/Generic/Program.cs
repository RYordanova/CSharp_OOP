using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>(4);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            Console.WriteLine(list);
            list.Remove(3);
            Console.WriteLine(list);
            list.Insert(3, 4);
            Console.WriteLine(list);
            Console.WriteLine("Index of 4: {0}", list.IndexOf(4));
            Console.WriteLine("Index of 8: {0}", list.IndexOf(8));
            Console.WriteLine("Max element: {0}", list.Max<int>());
            Console.WriteLine("Min element: {0}", list.Min<int>());

            list.Clear();
            Console.WriteLine(list);
        }
    }
}
