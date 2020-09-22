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
            var N = Scanner.Scan<long>();
            var prime = new Prime(N);
            var answer = 0;
            foreach (var count in prime.Factors.Values)
            {
                var i = 1;
                while (count >= i * (i + 1) / 2)
                {
                    i++;
                    answer++;
                }
            }
            Console.WriteLine(answer);
        }

        public class Prime
        {
            public Dictionary<long, int> Factors => new Dictionary<long, int>(_factors);
            private Dictionary<long, int> _factors;
            public Prime(long n)
            {
                _factors = new Dictionary<long, int>();
                var tmp = n;
                var max = (long)Math.Sqrt(n);
                var p = 2;
                while (p <= max)
                {
                    if (tmp % p == 0)
                    {
                        _factors[p] = 0;
                        while (tmp % p == 0)
                        {
                            tmp /= p;
                            _factors[p]++;
                        }
                    }
                    p++;
                }
                if (tmp > 1) _factors[tmp] = 1;
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
