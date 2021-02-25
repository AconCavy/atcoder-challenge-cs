using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
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
            var (H, W, N) = Scanner.Scan<int, int, int>();
            var (SR, SC) = Scanner.Scan<int, int>();
            var S = Scanner.Scan<string>();
            var T = Scanner.Scan<string>();
            var map1 = new Dictionary<char, int>();
            var map2 = new Dictionary<char, int>();
            map1['D'] = map2['U'] = 0;
            map1['R'] = map2['L'] = 1;
            map1['U'] = map2['D'] = 2;
            map1['L'] = map2['R'] = 3;

            var cs = new int[N, 4];
            var ct = new int[N, 4];
            for (var i = 0; i < N; i++) cs[i, map1[S[i]]]++;
            for (var i = 0; i < N; i++) ct[i, map2[T[i]]]++;

            var answer = true;
            for (var k = 0; k < 4; k++)
            {
                var isRow = k % 2 == 0;
                var isPos = k < 2;
                var c = isRow ? SR : SC;
                var max = isRow ? H : W;
                var m = isPos ? 1 : -1;

                for (var i = 0; i < N; i++)
                {
                    c += cs[i, k] * m;
                    if (isPos && max < c || !isPos && c <= 0) answer = false;

                    c -= ct[i, k] * m;
                    if (isPos) c = Math.Max(c, 1);
                    else c = Math.Min(c, max);
                }
            }

            Console.WriteLine(answer ? "YES" : "NO");
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
