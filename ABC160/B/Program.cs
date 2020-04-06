using System;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var coin500 = input / 500;
            var tmp = input % 500;
            var coin5 = tmp / 5;

            Console.WriteLine(coin500 * 1000 + coin5 * 5);
        }
    }
}
