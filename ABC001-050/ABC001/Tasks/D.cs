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
            var N = Scanner.Scan<int>();
            var SE = new (int L, int R)[N];
            for (var i = 0; i < N; i++)
            {
                var se = Scanner.Scan<string>().Split("-").Select(int.Parse).ToArray();
                var s = se[0];
                if (s % 5 != 0) s -= s % 5;
                var e = se[1];
                if (e % 5 != 0) e = e - e % 5 + 5;
                if (e - e / 100 * 100 == 60) e += 40;
                SE[i] = (s, e);
            }
            SE = SE.OrderBy(x => x.L).ThenBy(x => x.R).ToArray();
            var answer = new List<string>();
            var l = -1;
            var r = -1;
            foreach (var (s, e) in SE)
            {
                if (r < s)
                {
                    answer.Add($"{l:0000}-{r:0000}");
                    l = s;
                    r = e;
                    continue;
                }
                if (s < l) l = s;
                if (r < e) r = e;
            }
            answer.Add($"{l:0000}-{r:0000}");
            for (var i = 1; i < answer.Count; i++)
            {
                Console.WriteLine(answer[i]);
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
