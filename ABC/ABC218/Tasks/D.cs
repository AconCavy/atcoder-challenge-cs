using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
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
            var P = new (int X, int Y)[N];
            var dictX = new Dictionary<int, List<(int, int)>>();
            var dictY = new Dictionary<int, List<(int, int)>>();
            var hashset = new HashSet<(int, int)>();
            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                P[i] = (x, y);
                if (!dictX.ContainsKey(x)) dictX[x] = new List<(int, int)>();
                dictX[x].Add((x, y));
                if (!dictY.ContainsKey(y)) dictY[y] = new List<(int, int)>();
                dictY[y].Add((x, y));
                hashset.Add((x, y));
            }

            var answer = 0L;
            foreach (var (x1, y1) in P)
            {
                foreach (var (x2, y2) in dictX[x1])
                {
                    if (y2 == y1) continue;
                    foreach (var (x3, y3) in dictY[y1])
                    {
                        if (x3 == x1) continue;
                        if (hashset.Contains((x3, y2))) answer++;
                    }
                }
            }

            answer /= 4;
            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (queue.Count == 0) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
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
