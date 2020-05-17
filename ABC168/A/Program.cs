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
            var answer = "";
            switch (n % 10)
            {
                case 2:
                case 4:
                case 5:
                case 7:
                case 9:
                    answer = "hon";
                    break;
                case 0:
                case 1:
                case 6:
                case 8:
                    answer = "pon";
                    break;
                case 3:
                    answer = "bon";
                    break;
            }

            Console.WriteLine(answer);
        }
    }
}
