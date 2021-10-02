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
            var AB = new (int A, int B)[N];
            var hashset = new HashSet<int>();
            for (var i = 0; i < N; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                AB[i] = (a, b);
                hashset.Add(a);
                hashset.Add(a + b - 1);
                hashset.Add(a + b);
            }

            var tmp = hashset.OrderBy(x => x).Select((x, i) => (x, i)).ToList();
            var map = tmp.ToDictionary(k => k.x, k => k.i);
            var remap = tmp.ToDictionary(k => k.i, k => k.x);
            var imos = new int[map.Count + 1];
            foreach (var (a, b) in AB)
            {
                imos[map[a]]++;
                imos[map[a + b]]--;
            }

            for (var i = 1; i < imos.Length; i++)
            {
                imos[i] += imos[i - 1];
            }

            var answer = new long[N + 1];
            var prev = 0L;
            var pd = 0L;
            for (var i = 0; i < imos.Length; i++)
            {
                var curr = imos[i];
                if (curr != prev)
                {
                    var d = remap[i];
                    answer[prev] += d - pd;
                    pd = d;
                    prev = curr;
                }
            }

            Console.WriteLine(string.Join(" ", answer.Skip(1)));
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
