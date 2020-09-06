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
            var NK = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var N = NK[0];
            var K = NK[1];
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < A.Length; i++)
            {
                if (dict.ContainsKey(A[i])) dict[A[i]]++;
                else dict[A[i]] = 1;
            }
            var vals = dict.Select(x => x.Value).ToArray();
            Array.Sort(vals);
            var answer = 0;
            for (var i = 0; i < vals.Length - K; i++)
            {
                answer += vals[i];
                vals[vals.Length - 1] += vals[i];
            }
            Console.WriteLine(answer);
        }
    }
}
