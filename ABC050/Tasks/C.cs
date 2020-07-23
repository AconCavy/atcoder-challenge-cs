using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var p = (int)1e9 + 7;
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < N; i++)
            {
                if (!dict.ContainsKey(A[i])) dict[A[i]] = 0;
                dict[A[i]]++;
            }
            var ok = true;
            if (N % 2 == 0)
            {
                foreach (var x in dict)
                {
                    if (x.Key % 2 == 0) ok = false;
                    if (x.Value != 2) ok = false;
                }
            }
            else
            {
                var ZeroIs1 = dict[0] == 1;
                dict.Remove(0);
                var elements = true;
                foreach (var x in dict)
                {
                    if (x.Key % 2 == 1) elements = false;
                    if (x.Value != 2) elements = false;
                }
                ok = ZeroIs1 && elements;
            }
            var answer = 0L;
            if (ok)
            {
                answer = 1;
                for (var i = 0; i < N / 2; i++)
                {
                    answer *= 2;
                    answer %= p;
                }
            }
            Console.WriteLine(answer);
        }
    }
}
