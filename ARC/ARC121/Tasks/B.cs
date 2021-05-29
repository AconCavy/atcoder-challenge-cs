using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
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
            var D = new List<long>[3].Select(x => new List<long>()).ToArray();
            for (var i = 0; i < N * 2; i++)
            {
                var (a, c) = Scanner.Scan<long, char>();
                if (c == 'R') D[0].Add(a);
                if (c == 'G') D[1].Add(a);
                if (c == 'B') D[2].Add(a);
            }

            if (D.All(x => x.Count % 2 == 0))
            {
                Console.WriteLine(0);
                return;
            }

            for (var i = 0; i < 3; i++) D[i].Sort();

            const long inf = (long)1e18;
            var answer = inf;

            long Check(List<long> source1, List<long> source2)
            {
                var min = inf;
                for (var i = 0; i < source1.Count; i++)
                {
                    var lb = LowerBound(source2, source1[i]);
                    min = Math.Min(min, Math.Abs(source1[i] - source2[lb]));
                    if (lb + 1 < source2.Count) min = Math.Min(min, Math.Abs(source1[i] - source2[lb + 1]));
                    if (lb - 1 >= 0) min = Math.Min(min, Math.Abs(source1[i] - source2[lb - 1]));
                }

                return min;
            }

            if ((D[0].Count % 2, D[1].Count % 2) == (1, 1)) answer = Math.Min(answer, Check(D[0], D[1]));
            if ((D[0].Count % 2, D[2].Count % 2) == (1, 1)) answer = Math.Min(answer, Check(D[0], D[2]));
            if ((D[1].Count % 2, D[2].Count % 2) == (1, 1)) answer = Math.Min(answer, Check(D[1], D[2]));

            if (D[0].Count != 0 && D[1].Count != 0 && D[2].Count != 0)
            {
                answer = Math.Min(answer, Check(D[0], D[1]) + Check(D[0], D[2]));
                answer = Math.Min(answer, Check(D[0], D[1]) + Check(D[1], D[2]));
                answer = Math.Min(answer, Check(D[0], D[2]) + Check(D[1], D[2]));
            }

            Console.WriteLine(answer);
        }

        public static int LowerBound(List<long> source, long key)
        {
            var (l, r) = (-1, source.Count - 1);
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                if (source[m] >= key) r = m;
                else l = m;
            }
            return r;
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
