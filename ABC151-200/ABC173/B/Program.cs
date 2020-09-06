using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
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
            var N = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, int>();
            dict["AC"] = 0;
            dict["WA"] = 0;
            dict["TLE"] = 0;
            dict["RE"] = 0;
            for (var i = 0; i < N; i++)
            {
                var s = Console.ReadLine();
                dict[s]++;
            }
            Console.WriteLine($"AC x {dict["AC"]}");
            Console.WriteLine($"WA x {dict["WA"]}");
            Console.WriteLine($"TLE x {dict["TLE"]}");
            Console.WriteLine($"RE x {dict["RE"]}");
        }
    }
}
