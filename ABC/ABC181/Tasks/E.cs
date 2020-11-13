using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class E
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
            var (N, M) = Scanner.Scan<int, int>();
            var H = Scanner.ScanEnumerable<long>().ToArray();
            var W = Scanner.ScanEnumerable<long>().ToArray();
            Array.Sort(H);
            var sum1 = new long[(N + 1) / 2];
            var sum2 = new long[(N + 1) / 2];
            for (var i = 0; i + 1 < N; i += 2) sum1[i / 2 + 1] = sum1[i / 2] + H[i + 1] - H[i];
            for (var i = N - 2; i > 0; i -= 2) sum2[i / 2] = sum2[i / 2 + 1] + H[i + 1] - H[i];
            var answer = (long)1e18;
            foreach (var w in W)
            {
                var lb = Array.BinarySearch(H, w);
                if (lb < 0) lb = ~lb;
                if ((lb & 1) != 0) lb ^= 1;
                answer = Math.Min(answer, sum1[lb / 2] + sum2[lb / 2] + Math.Abs(H[lb] - w));
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
