using System;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var nk = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToList();
            var n = nk[0];
            var k = nk[1];
            var sum = n * (n - 1) / 2;
            var numbers = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToList();
            numbers.Sort();
        }
    }
}
