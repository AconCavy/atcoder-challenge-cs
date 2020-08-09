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
            var N = Scanner.Scan<int>();
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            var inf = -(int)1e9;
            var answer = inf;
            for (var i = 0; i < N; i++)
            {
                var (ta, ao) = (inf, inf);
                for (var j = 0; j < N; j++)
                {
                    if (i == j) continue;
                    var l = Math.Min(i, j);
                    var r = Math.Max(i, j);
                    var s = 0;
                    var t = 0;
                    for (var k = l + 1; k <= r; k += 2)
                    {
                        s += A[k];
                    }
                    for (var k = l; k <= r; k += 2)
                    {
                        t += A[k];
                    }
                    if (s > ao)
                    {
                        ao = s;
                        ta = t;
                    }
                }
                answer = Math.Max(answer, ta);
            }

            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (!queue.Any()) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
                return (T)Convert.ChangeType(queue.Dequeue(), typeof(T));
            }
            public static T Scan<T>() => Next<T>();
            public static (T1, T2) Scan<T1, T2>() => (Next<T1>(), Next<T2>());
            public static (T1, T2, T3) Scan<T1, T2, T3>() => (Next<T1>(), Next<T2>(), Next<T3>());
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>());
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>());
        }
    }
}
