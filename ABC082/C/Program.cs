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
            var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(ai);
            var tmp = ai.Append(0).ToArray();
            var answer = 0;
            var count = 0;
            var x = 0;
            for (var i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] == x)
                {
                    count++;
                }
                else
                {
                    if (count < x) answer += count;
                    else answer += count - x;
                    x = tmp[i];
                    count = 1;
                }
            }
            Console.WriteLine(answer);
        }
    }
}
