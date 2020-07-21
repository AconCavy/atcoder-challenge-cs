using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class B
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
            var S = Console.ReadLine().ToCharArray().Select(x => x == 'I' ? 1 : -1).ToArray();
            var answer = 0;
            var current = 0;
            for (var i = 0; i < N; i++)
            {
                current += S[i];
                answer = Math.Max(answer, current);
            }

            Console.WriteLine(answer);
        }
    }
}
