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
            var dictS = new Dictionary<string, int>();
            for (var i = 0; i < N; i++)
            {
                var s = Console.ReadLine();
                if (!dictS.ContainsKey(s)) dictS[s] = 0;
                dictS[s]++;
            }
            var M = int.Parse(Console.ReadLine());
            var dictT = new Dictionary<string, int>();
            for (var i = 0; i < M; i++)
            {
                var t = Console.ReadLine();
                if (!dictT.ContainsKey(t)) dictT[t] = 0;
                dictT[t]++;
            }
            var answer = 0;
            foreach (var s in dictS.Keys)
            {
                if (dictT.ContainsKey(s)) answer = Math.Max(answer, dictS[s] - dictT[s]);
                else answer = Math.Max(answer, dictS[s]);
            }
            Console.WriteLine(answer);
        }
    }
}
