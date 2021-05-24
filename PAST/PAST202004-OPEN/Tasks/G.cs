using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class G
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
            var Q = Scanner.Scan<int>();

            var idx = 0;
            var list = new List<(int C, int X)>();

            while (Q-- > 0)
            {
                var query = Scanner.ScanEnumerable<string>().ToArray();
                if (query[0] == "1")
                {
                    var (c, x) = (query[1][0] - 'a', int.Parse(query[2]));
                    list.Add((c, x));
                }
                else
                {
                    var d = int.Parse(query[1]);
                    if (idx >= list.Count) { Console.WriteLine(0); continue; }
                    var del = new long[26];
                    while (idx < list.Count && d > 0)
                    {
                        var (c, x) = list[idx];
                        var min = Math.Min(d, x);
                        del[c] += min;
                        d -= min;
                        list[idx] = (c, x - min);
                        if (list[idx].X == 0) idx++;
                    }

                    var answer = del.Sum(x => x * x);
                    Console.WriteLine(answer);
                }
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
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
