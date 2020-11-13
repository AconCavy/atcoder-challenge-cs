using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
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
            var (A, B, Q) = Scanner.Scan<int, int, int>();
            var S = new long[A].Select(_ => Scanner.Scan<long>()).ToList();
            var T = new long[B].Select(_ => Scanner.Scan<long>()).ToList();
            var X = new long[Q].Select(_ => Scanner.Scan<long>()).ToArray();
            const long inf = (long)1e18;
            S.Add(-inf); S.Add(inf);
            T.Add(-inf); T.Add(inf);
            S.Sort(); T.Sort();
            foreach (var x in X)
            {
                var slb = ~S.BinarySearch(x);
                var tlb = ~T.BinarySearch(x);
                var answer = inf;
                foreach (var s in new[] { S[slb - 1], S[slb] })
                    foreach (var t in new[] { T[tlb - 1], T[tlb] })
                    {
                        answer = Math.Min(answer, Math.Abs(s - x) + Math.Abs(t - s));
                        answer = Math.Min(answer, Math.Abs(t - x) + Math.Abs(s - t));
                    }
                Console.WriteLine(answer);
            }
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
