using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class C
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
            var N = Scanner.Scan<int>();
            var lt = new List<(int A, int B)>();
            var eq = new List<(int A, int B)>();
            var gt = new List<(int A, int B)>();
            for (var i = 0; i < N; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                if (a == b) eq.Add((a, b));
                if (a < b) lt.Add((a, b));
                else gt.Add((a, b));
            }

            lt.Sort((x, y) => x.A.CompareTo(y.A));
            gt.Sort((x, y) => y.B.CompareTo(x.B));

            var answer = 0L;
            var current = 0L;
            foreach (var (a, b) in lt)
            {
                answer = Math.Max(answer, current + a);
                current += a - b;
            }
            foreach (var (a, b) in eq)
            {
                answer = Math.Max(answer, current + a);
                current += a - b;
            }
            foreach (var (a, b) in gt)
            {
                answer = Math.Max(answer, current + a);
                current += a - b;
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
