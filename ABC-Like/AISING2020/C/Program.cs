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
            var counts = new int[N + 1];
            for (var x = 1; x * x <= N; x++)
            {
                for (var y = 1; y * y <= N; y++)
                {
                    for (var z = 1; z * z <= N; z++)
                    {
                        var tmp = x * x + y * y + z * z + x * y + y * z + z * x;
                        if (tmp > N) continue;
                        counts[tmp]++;
                    }
                }
            }

            for (var n = 1; n <= N; n++)
            {
                Console.WriteLine(counts[n]);
            }
        }
    }
}
