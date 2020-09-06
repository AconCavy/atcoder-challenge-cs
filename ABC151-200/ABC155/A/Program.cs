using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Trim().Split(' ');
            var count = 0;
            if (list[0] == list[1]) count++;
            if (list[0] == list[2]) count++;
            if (list[1] == list[2]) count++;

            Console.WriteLine(count == 1 ? "Yes" : "No");
        }
    }
}
