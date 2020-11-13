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
            var (N, K) = Scanner.Scan<int, int>();
            var A = Scanner.ScanEnumerable<long>().ToArray();
            const int p = (int)1e9 + 7;
            var minus = new List<long>();
            var plus = new List<long>();
            foreach (var a in A)
            {
                if (a < 0) minus.Add(a);
                else plus.Add(a);
            }
            minus = minus.OrderBy(x => x).ToList();
            plus = plus.OrderByDescending(x => x).ToList();
            var answer = 1L;
            if (K % 2 == 1)
            {
                if (plus.Count > 0)
                {
                    answer = plus.First();
                    plus.RemoveAt(0);
                }
                else
                {
                    answer = minus.Last();
                    minus.RemoveAt(minus.Count - 1);
                }
            }

            if (plus.Count % 2 == 1)
            {
                minus.Add(plus[plus.Count - 1]);
                plus.RemoveAt(plus.Count - 1);
            }

            var muls = new List<long>();
            if (answer < 0)
            {
                for (var i = plus.Count - 1; i - 1 >= 0; i -= 2) muls.Add(plus[i] * plus[i - 1]);
                for (var i = minus.Count - 1; i - 1 >= 0; i -= 2) muls.Add(minus[i] * minus[i - 1]);
                muls = muls.OrderBy(x => x).ToList();
            }
            else
            {
                for (var i = 0; i + 1 < plus.Count; i += 2) muls.Add(plus[i] * plus[i + 1]);
                for (var i = 0; i + 1 < minus.Count; i += 2) muls.Add(minus[i] * minus[i + 1]);
                muls = muls.OrderByDescending(x => x).ToList();
            }

            for (var i = 0; i < K / 2; i++)
            {
                answer *= muls[i] % p;
                while (answer < 0) answer += p;
                answer %= p;
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
