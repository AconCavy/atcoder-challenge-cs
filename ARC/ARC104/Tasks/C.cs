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
            const int inf = (int)1e9;
            var A = new int[N];
            var B = new int[N];
            var C = Enumerable.Repeat(-inf, N).ToArray();
            var info = new bool[N * 2 + 1];
            var answer = true;
            var getOn = Enumerable.Repeat(-inf, N * 2 + 1).ToArray();
            var getOff = Enumerable.Repeat(-inf, N * 2 + 1).ToArray();

            for (var i = 0; i < N; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                A[i] = a;
                B[i] = b;
                if (a > 0)
                {
                    if (info[a]) answer = false;
                    else info[a] = true;
                    getOn[a] = i;
                }
                if (b > 0)
                {
                    if (info[b]) answer = false;
                    else info[b] = true;
                    getOff[b] = i;
                }
                if (a > 0 && b > 0)
                {
                    if (b <= a) answer = false;
                    C[i] = b - a - 1;
                }
            }
            if (!answer) { Console.WriteLine("No"); return; }
            var list = new List<int>();
            for (var n = 1; n <= N * 2 && answer; n++)
            {
                var on = getOn[n];
                var off = getOff[n];
                if (on >= 0)
                {
                    if (C[on] != -inf)
                    {
                        if (list.Any(x => C[x] != C[on])) answer = false;
                        else list.Add(on);
                    }
                }

                if (off >= 0)
                {
                    list.Remove(off);
                }
            }

            Console.WriteLine(answer ? "Yes" : "No");
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
