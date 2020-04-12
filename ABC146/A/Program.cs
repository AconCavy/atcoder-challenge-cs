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
            var s = Console.ReadLine();
            var day = 0;
            switch (s)
            {
                case "SUN": day = 7; break;
                case "MON": day = 6; break;
                case "TUE": day = 5; break;
                case "WED": day = 4; break;
                case "THU": day = 3; break;
                case "FRI": day = 2; break;
                case "SAT": day = 1; break;
                default: break;
            }
            Console.WriteLine(day);
        }
    }
}
