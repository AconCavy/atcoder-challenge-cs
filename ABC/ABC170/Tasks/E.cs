using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class E
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
            var (N, Q) = Scanner.Scan<int, int>();
            int Ascending((int i, int rate) x, (int i, int rate) y)
            {
                var comparer = Comparer<int>.Default;
                var ret = comparer.Compare(x.rate, y.rate);
                return ret == 0 ? comparer.Compare(x.i, y.i) : ret;
            }
            int Descending((int i, int rate) x, (int i, int rate) y)
            {
                var comparer = Comparer<int>.Default;
                var ret = comparer.Compare(y.rate, x.rate);
                return ret == 0 ? comparer.Compare(y.i, x.i) : ret;
            }
            var ascending = Comparer<(int i, int rate)>.Create(Ascending);
            var descending = Comparer<(int i, int rate)>.Create(Descending);
            var depts = new SortedSet<(int i, int rate)>[200000]
                .Select(x => new SortedSet<(int i, int rate)>(descending)).ToArray();
            var data = new (int Rate, int Dept)[N];
            for (var i = 0; i < N; i++)
            {
                var (A, B) = Scanner.Scan<int, int>();
                B--;
                data[i] = (A, B);
                depts[B].Add((i, A));
            }

            var max = new SortedSet<(int i, int rate)>(depts.Where(x => x.Any())
                .Select(x => x.First()), ascending);
            for (var i = 0; i < Q; i++)
            {
                var (C, D) = Scanner.Scan<int, int>();
                C--;
                D--;
                var (rate, from) = data[C];
                data[C].Dept = D;

                max.Remove(depts[from].First());
                if (depts[D].Any()) max.Remove(depts[D].First());

                depts[from].Remove((C, rate));
                depts[D].Add((C, rate));

                if (depts[from].Any()) max.Add(depts[from].First());
                max.Add(depts[D].First());
                Console.WriteLine(max.First().rate);
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
