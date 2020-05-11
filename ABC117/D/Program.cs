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
            var nk = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var ai = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            if (nk[1] == 0)
            {
                Console.WriteLine(ai.Sum());
                return;
            }

            var maxBit = 0;
            var tmp = nk[1];
            while (tmp > 1)
            {
                tmp >>= 1;
                maxBit++;
            }

            var x = 0L;
            for (var b = maxBit; b >= 0; b--)
            {
                if ((x | (1L << b)) > nk[1]) continue;
                var bit1 = 0;
                for (var i = 0; i < ai.Length; i++)
                {
                    if (((ai[i] >> b) & 1) == 1) bit1++;
                }
                if (bit1 < (ai.Length + 1) / 2) x |= (1L << b);
            }
            Console.WriteLine(ai.Select(a => x ^ a).Sum());
        }
    }
}
