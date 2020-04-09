using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var x = int.Parse(Console.ReadLine());

            while (true)
            {
                if (IsPrime(x))
                {
                    Console.WriteLine(x);
                    break;
                }
                x++;
            }
        }

        static bool IsPrime(int x)
        {
            if (x < 2) return false;
            if (x == 2) return true;
            if (x % 2 == 0) return false;
            var sqrt = Math.Sqrt(x);
            for (var i = 3; i < sqrt; i++) if (x % i == 0) return false;
            return true;
        }
    }
}
