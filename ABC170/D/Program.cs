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
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(A);
            var max = A[N - 1] + 1;
            var answer = new bool[max];
            var tmp = new bool[max];
            foreach (var n in A)
            {
                if (answer[n]) answer[n] = false;
                if (tmp[n]) continue;
                answer[n] = true;
                for (var i = n; i < tmp.Length; i += n)
                {
                    tmp[i] = true;
                }
            }
            Console.WriteLine(answer.Count(x => x));
        }
    }
}
