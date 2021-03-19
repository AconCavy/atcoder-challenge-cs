using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class H
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
            var N = Scanner.Scan<long>();

            long F(IEnumerable<int> source)
            {
                var ret = 0L;
                foreach (var d in source)
                {
                    ret *= 10;
                    ret += d;
                }

                return ret;
            }

            var sum = N.ToString().Sum(x => x - '0');
            var list = new List<int>();
            while (sum > 0)
            {
                list.Add(Math.Min(9, sum));
                sum -= 9;
            }
            list.Reverse();

            var answer = F(list);
            if (answer == N)
            {
                const long inf = (long)1e18;
                var sub1 = list.ToList();
                var sub2 = list.ToList();
                var (a, b) = (inf, inf);

                if (sub1.Count > 1 && sub1[0] < 9)
                {
                    sub1[0]++;
                    sub1[1]--;
                    a = F(sub1);
                }

                sub2[0]--;
                sub2.Insert(0, 1);
                b = F(sub2);

                answer = Math.Min(a, b);
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
