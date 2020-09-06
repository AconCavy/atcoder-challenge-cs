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
            var N = int.Parse(Console.ReadLine());
            var S = new string[2].Select(x => x = Console.ReadLine()).ToArray();
            var p = 1000000007;

            // v : 3C1 = 3
            // h : 3C2 = 6
            // v+h : 2
            // v+v : 2
            // h+v : 1
            // h+h : 3

            var order = new List<bool>();
            for (var i = 0; i < N; i++)
            {
                var tmp = S[0][i] == S[1][i];
                order.Add(tmp);
                if (!tmp) i++;
            }

            var answer = order[0] ? 3L : 6L;
            for (var i = 1; i < order.Count; i++)
            {
                if (order[i - 1]) answer *= 2;
                else if (!order[i]) answer *= 3;
                answer %= p;
            }

            Console.WriteLine(answer);
        }
    }
}
