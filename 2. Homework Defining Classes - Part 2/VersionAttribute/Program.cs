using System;
using System.Linq;
using System.Reflection;

namespace VersionAttribute
{
    [Version("3.13")]
    public class Program
    {
        static void Main(string[] args)
        {
            string version = typeof(Program).GetCustomAttributes<Version>().First().Ver;
            Console.WriteLine(version);
        }
    }
}
