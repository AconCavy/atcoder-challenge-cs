using System;
using System.Linq;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Console.WriteLine((input[2] == input[3] && input[4] == input[5]) ? "Yes" : "No");
        }
    }
}
