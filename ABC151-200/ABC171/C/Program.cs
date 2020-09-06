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
            var N = long.Parse(Console.ReadLine());
            var answer = "";
            while (N > 0)
            {
                var div = (N - 1) / 26L;
                var mod = (N - 1) % 26L;
                answer += (char)('a' + mod);
                N = div;
            }
            Console.WriteLine(string.Join("", answer.Reverse()));
        }
    }
}
