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
            var counts = Enumerable.Repeat((int)1e9, 26).ToArray();
            var answer = "";
            for (var i = 0; i < N; i++)
            {
                var s = Console.ReadLine();
                var tmp = new int[26];
                for (var j = 0; j < s.Length; j++)
                {
                    tmp[s[j] - 'a']++;
                }

                for (var j = 0; j < tmp.Length; j++)
                {
                    counts[j] = Math.Min(counts[j], tmp[j]);
                }
            }

            for (var i = 0; i < counts.Length; i++)
            {
                for (var j = 0; j < counts[i]; j++)
                {
                    answer += Convert.ToChar('a' + i);
                }
            }
            Console.WriteLine(answer);
        }
    }
}
