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
            var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).OrderByDescending(x => x).ToArray();
            var list = new List<long>();
            list.Add(0);
            list.Add(A[0]);
            var answer = 0L;
            for (var i = 1; list.Count < N; i++)
            {
                list.Add(A[i]);
                list.Add(A[i]);
            }
            answer = list.Sum();
            if (list.Count > N) answer -= list[list.Count - 1];
            Console.WriteLine(answer);
        }
    }
}
