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
            var N = 9;
            var M = Scanner.Scan<int>();
            var G = new List<int>[N].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (u, v) = Scanner.Scan<int, int>();
                u--; v--;
                G[u].Add(v);
                G[v].Add(u);
            }
            var P = Scanner.ScanEnumerable<int>().Select(x => x - 1).ToArray();

            const string goal = "123456789";
            var tmp = new char[N];
            Array.Fill(tmp, '9');
            for (var i = 0; i < N - 1; i++)
            {
                tmp[P[i]] = (char)(i + '1');
            }
            var start = new string(tmp);

            var queue = new Queue<string>();
            var dict = new Dictionary<string, int>();
            queue.Enqueue(new string(start));
            dict[new string(start)] = 0;

            while (queue.Count > 0)
            {
                var s = queue.Dequeue();
                var sarr = s.ToCharArray();
                var u = s.IndexOf('9');

                foreach (var v in G[u])
                {
                    var tarr = s.ToArray();
                    (tarr[u], tarr[v]) = (tarr[v], tarr[u]);
                    var t = new string(tarr);
                    if (dict.ContainsKey(new string(t))) continue;
                    dict[t] = dict[s] + 1;
                    queue.Enqueue(t);
                }
            }

            var answer = dict.ContainsKey(goal) ? dict[goal] : -1;
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
