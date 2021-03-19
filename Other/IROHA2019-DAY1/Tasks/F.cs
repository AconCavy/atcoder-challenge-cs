using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class F
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
            var (N, K) = Scanner.Scan<long, int>();
            var answer = new List<long>();
            var rem = 1L;
            foreach (var (k, v) in GetFactors(N))
            {
                var s = answer.Count;
                var t = Math.Min(s + v, K - 1);
                for (var i = s; i < t; i++) answer.Add(k);

                if (s + v - t > 0) rem *= (long)Math.Pow(k, s + v - t);
            }

            if (rem > 1) answer.Add(rem);
            answer.Sort();
            if (answer.Count < K) Console.WriteLine(-1);
            else Console.WriteLine(string.Join(" ", answer));

        }
        public static IDictionary<long, int> GetFactors(long value)
        {
            var factors = new Dictionary<long, int>();
            if (value < 2) return factors;
            void CountUp(long n)
            {
                if (value % n != 0) return;
                factors[n] = 0;
                while (value % n == 0)
                {
                    value /= n;
                    factors[n]++;
                }
            }
            CountUp(2);
            for (var i = 3L; i * i <= value; i += 2) CountUp(i);
            if (value > 1) factors[value] = 1;
            return factors;
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
