using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine("Hello World");
                return;
            }
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            Console.WriteLine(a + b);
        }
    }
}
