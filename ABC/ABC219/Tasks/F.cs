using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class F
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
            var S = Scanner.Scan<string>();
            var K = Scanner.Scan<long>();

            var hashset = new HashSet<(long, long)>();
            var (cx, cy) = (0L, 0L);
            hashset.Add((cx, cy));
            var dict = new Dictionary<char, (int, int)>
            {
                ['L'] = (-1, 0),
                ['R'] = (+1, 0),
                ['U'] = (0, -1),
                ['D'] = (0, +1)
            };

            var answer = (long)hashset.Count;
            var loop = 0L;
            var pd = 0L;
            while (loop < K)
            {
                foreach (var c in S)
                {
                    var (dx, dy) = dict[c];
                    cx += dx;
                    cy += dy;
                    hashset.Add((cx, cy));
                }

                var curr = hashset.Count;
                var cd = curr - answer;
                if (cd == pd)
                {
                    answer += cd * (K - loop);
                    break;
                }

                answer = curr;
                pd = cd;
                loop++;
            }

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
