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
            var V = Scanner.ScanEnumerable<int>().ToArray();
            var dict1 = new Dictionary<int, int>();
            var dict2 = new Dictionary<int, int>();
            for (var i = 0; i < N; i++)
            {
                if (i % 2 == 0)
                {
                    if (!dict1.ContainsKey(V[i])) dict1[V[i]] = 0;
                    dict1[V[i]]++;
                }
                else
                {
                    if (!dict2.ContainsKey(V[i])) dict2[V[i]] = 0;
                    dict2[V[i]]++;
                }
            }

            var odd = dict1.Select(x => (x.Key, x.Value)).ToArray();
            var even = dict2.Select(x => (x.Key, x.Value)).ToArray();
            Array.Sort(odd, (x, y) => y.Value.CompareTo(x.Value));
            Array.Sort(even, (x, y) => y.Value.CompareTo(x.Value));
            var answer = N;
            if (odd[0].Key != even[0].Key) answer -= odd[0].Value + even[0].Value;
            else
            {
                if (odd.Length == 1 || even.Length == 1)
                {
                    if (even.Length != 1) answer -= odd[0].Value + even[1].Value;
                    else if (odd.Length != 1) answer -= odd[1].Value + even[0].Value;
                    else answer -= Math.Min(odd[0].Value, even[0].Value);
                }
                else answer -= Math.Max(odd[0].Value + even[1].Value, odd[1].Value + even[0].Value);
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
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
