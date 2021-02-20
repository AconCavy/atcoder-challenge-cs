using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class F
    {
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (N, X) = Scanner.Scan<int, long>();
            var A = Scanner.ScanEnumerable<long>().ToArray();
            Array.Sort(A, (x, y) => y.CompareTo(x));
            var even = new List<long>();
            var odd = new List<long>();
            foreach (var a in A) (a % 2 == 0 ? even : odd).Add(a);
            var ecum = new long[even.Count + 1];
            var ocum = new long[odd.Count + 1];
            for (var i = 0; i < even.Count; i++) ecum[i + 1] = ecum[i] + even[i];
            for (var i = 0; i < odd.Count; i++) ocum[i + 1] = ocum[i] + odd[i];

            var answer = X;
            for (var i = 0; i <= even.Count; i++)
            {
                for (var j = 0; j <= odd.Count; j++)
                {
                    if (i + j == 0) continue;
                    var x = X - (ecum[i] + ocum[j]);
                    if (x % (i + j) == 0) answer = Math.Min(answer, x / (i + j));
                }
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
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
