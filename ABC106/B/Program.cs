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
            var n = int.Parse(Console.ReadLine());
            var answer = 0;
            for (var i = 1; i <= n; i += 2)
            {
                var count = 0;
                for (var j = 1; j <= i; j++)
                {
                    if (i % j == 0) count++;
                }
                if (count == 8) answer++;
            }
            Console.WriteLine(answer);
        }
    }
}
