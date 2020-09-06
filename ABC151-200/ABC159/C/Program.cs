using System;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray()[0];
            var tmp = l / 3.0;
            Console.WriteLine(tmp * tmp * tmp);
        }
    }
}
