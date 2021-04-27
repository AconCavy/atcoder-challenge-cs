using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

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
            var (N, K) = Scanner.Scan<int, int>();
            var A = Scanner.ScanEnumerable<int>().ToArray();
            var S = new string[N].Select(_ => Scanner.Scan<string>()).ToArray();

            if (N == K)
            {
                Console.WriteLine();
                return;
            }

            var T0 = new string[K];
            var T1 = new string[N - K];
            var used = new bool[N];
            for (var i = 0; i < K; i++)
            {
                var j = A[i] - 1;
                T0[i] = S[j];
                used[j] = true;
            }

            var idx = 0;
            for (var i = 0; i < N; i++)
            {
                if (!used[i]) T1[idx++] = S[i];
            }

            Array.Sort(T0, (x, y) => x.Length.CompareTo(y.Length));

            var (l, r) = (0, T0[0].Length + 1);
            var min = T0[0];

            while (r - l > 1)
            {
                var m = (l + r) / 2;
                var tmp = min[..m];
                var ok = true;
                foreach (var t in T0)
                {
                    ok &= t.StartsWith(tmp);
                    if (!ok) break;
                }

                if (ok) l = m;
                else r = m;
            }

            (l, r) = (-1, l);
            while (r - l > 1)
            {
                var m = (l + r) / 2;
                var tmp = min[..m];
                var ok = true;
                foreach (var t in T1)
                {
                    ok &= !t.StartsWith(tmp);
                    if (!ok) break;
                }

                if (ok) r = m;
                else l = m;
            }

            var answer = min[..r];
            if (T1.Any(x => x.StartsWith(answer))) answer = "-1";
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
