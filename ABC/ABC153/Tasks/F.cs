using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class F
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
            var (N, D, A) = Scanner.Scan<int, int, int>();
            var E = new (int X, long H)[N];
            for (var i = 0; i < N; i++)
            {
                var (x, h) = Scanner.Scan<int, long>();
                E[i] = (x, h);
            }
            Array.Sort(E, (x, y) => Comparer<int>.Default.Compare(x.X, y.X));
            var counts = new long[N + 1];
            var answer = 0L;
            var current = 0L;
            for (var i = 0; i < N; i++)
            {
                var h = E[i].H;
                current -= counts[i];
                var damage = current * A;
                h -= damage;
                if (h <= 0) continue;

                var count = h / A;
                if (h % A > 0) count++;
                current += count;
                answer += count;

                var l = i;
                var r = N;
                while (r - l > 1)
                {
                    var m = l + (r - l) / 2;
                    if (E[m].X - E[i].X <= D * 2) l = m;
                    else r = m;
                }
                counts[r] += count;
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
