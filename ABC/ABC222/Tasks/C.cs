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
            var (N, M) = Scanner.Scan<int, int>();
            var A = new char[N * 2][];
            for (var i = 0; i < N * 2; i++)
            {
                A[i] = Scanner.Scan<string>().ToCharArray();
            }

            var list = new List<(int Id, int Win)>();

            for (var i = 0; i < N * 2; i++)
            {
                list.Add((i, 0));
            }

            for (var i = 0; i < M; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    var (id1, win1) = list[j * 2];
                    var (id2, win2) = list[j * 2 + 1];

                    var (l, r) = (A[id1][i], A[id2][i]);
                    if (l == r) continue;
                    if (l == 'G' && r == 'C') list[j * 2] = (id1, win1 + 1);
                    if (l == 'G' && r == 'P') list[j * 2 + 1] = (id2, win2 + 1);
                    if (l == 'C' && r == 'P') list[j * 2] = (id1, win1 + 1);
                    if (l == 'C' && r == 'G') list[j * 2 + 1] = (id2, win2 + 1);
                    if (l == 'P' && r == 'G') list[j * 2] = (id1, win1 + 1);
                    if (l == 'P' && r == 'C') list[j * 2 + 1] = (id2, win2 + 1);
                }

                list.Sort((x, y) =>
                {
                    var ret = y.Win.CompareTo(x.Win);
                    return ret == 0 ? x.Id.CompareTo(y.Id) : ret;
                });
            }

            foreach (var (id, _) in list)
            {
                Console.WriteLine(id + 1);
            }
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
