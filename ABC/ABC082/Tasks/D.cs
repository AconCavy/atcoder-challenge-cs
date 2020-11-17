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
            var S = Scanner.Scan<string>();
            var (X, Y) = Scanner.Scan<int, int>();
            var d = new List<int>() { 0 };
            var idx = 0;
            foreach (var c in S)
            {
                if (c == 'F') d[idx]++;
                else
                {
                    idx++;
                    d.Add(0);
                }
            }

            var dx = new List<int>();
            var dy = new List<int>();
            for (var i = 1; i < d.Count; i++)
            {
                (i % 2 == 0 ? dx : dy).Add(d[i]);
            }

            const int max = 16001;
            const int origin = max / 2;
            var dpx = new bool[dx.Count + 1, max];
            var dpy = new bool[dy.Count + 1, max];
            dpx[0, origin + d[0]] = true;
            for (var i = 0; i < dx.Count; i++)
            {
                for (var j = 0; j < max; j++)
                {
                    if (!dpx[i, j]) continue;
                    dpx[i + 1, j + dx[i]] = true;
                    dpx[i + 1, j - dx[i]] = true;
                }
            }

            dpy[0, origin] = true;
            for (var i = 0; i < dy.Count; i++)
            {
                for (var j = 0; j < max; j++)
                {
                    if (!dpy[i, j]) continue;
                    dpy[i + 1, j + dy[i]] = true;
                    dpy[i + 1, j - dy[i]] = true;
                }
            }
            var answer = dpx[dx.Count, origin + X] && dpy[dy.Count, origin + Y];
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
