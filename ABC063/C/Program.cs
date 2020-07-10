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
            var N = int.Parse(Console.ReadLine());
            var Scores = new int[N].Select(x => x = int.Parse(Console.ReadLine())).ToArray();
            var sum = Scores.Sum();
            if (sum % 10 != 0)
            {
                Console.WriteLine(sum);
                return;
            }
            Array.Sort(Scores);
            var x10 = true;
            for (var i = 0; i < Scores.Length; i++)
            {
                if (Scores[i] % 10 != 0)
                {
                    sum -= Scores[i];
                    x10 = false;
                    break;
                }
            }
            if (x10) sum = 0;
            Console.WriteLine(sum);
        }
    }
}
