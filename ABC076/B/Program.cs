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
            var K = int.Parse(Console.ReadLine());
            var answer = (long)1e18;
            for (var bit = 0; bit < (1 << N); bit++)
            {
                var num = 1;
                for (var i = 0; i < N; i++)
                {
                    if (((bit >> i) & 1) == 1) num *= 2;
                    else num += K;
                }
                answer = Math.Min(answer, num);
            }
            Console.WriteLine(answer);
        }
    }
}
