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
            var ai = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            if (ai.Contains(0))
            {
                Console.WriteLine(0);
                return;
            }
            var limit = (long)1e18;
            var answer = 1L;
            for (var i = 0; i < ai.Length; i++)
            {
                try
                {
                    checked
                    {
                        answer *= ai[i];
                    }
                }
                catch
                {
                    Console.WriteLine(-1);
                    return;
                }
                if (answer > limit)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
            Console.WriteLine(answer);
        }
    }
}
