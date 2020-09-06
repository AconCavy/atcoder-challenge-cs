using System;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var list = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).Where(x => x % 2 == 0).ToArray();
            Console.WriteLine((list.Where(x => (x % 3 == 0 || x % 5 == 0)).Count() == list.Count()) ? "APPROVED" : "DENIED");
        }
    }
}
