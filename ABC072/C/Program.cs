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
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = 0;
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < A.Length; i++)
            {
                if (dict.ContainsKey(A[i])) dict[A[i]]++;
                else dict[A[i]] = 1;
            }

            foreach (var val in dict.Keys)
            {
                var tmp = dict[val];
                tmp += dict.ContainsKey(val - 1) ? dict[val - 1] : 0;
                tmp += dict.ContainsKey(val + 1) ? dict[val + 1] : 0;
                answer = Math.Max(answer, tmp);
            }

            Console.WriteLine(answer);
        }
    }
}
