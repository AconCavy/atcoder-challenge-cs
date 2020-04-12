using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
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
            var n = long.Parse(Console.ReadLine());
            var s = Console.ReadLine();
            long r = 0;
            long g = 0;
            long b = 0;
            for (var i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'R': r++; break;
                    case 'G': g++; break;
                    case 'B': b++; break;
                }
            }

            long count = r * g * b;
            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    var k = j + j - i;
                    if (k >= n) continue;
                    if (s[i] != s[j] && s[i] != s[k] && s[j] != s[k]) count--;
                }
            }
            Console.WriteLine(count);
        }
    }
}
