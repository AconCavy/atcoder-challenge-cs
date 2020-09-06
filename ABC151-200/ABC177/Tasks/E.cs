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
            var N = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var max = (int)1e6 + 1;
            var sieve = new int[max];
            foreach (var a in A) sieve[a]++;

            var isPairwise = true;
            for (var i = 2; i < max && isPairwise; i++)
            {
                var count = 0;
                for (var j = i; j < max; j += i)
                {
                    count += sieve[j];
                }
                if (count > 1) isPairwise = false;
            }
            if (isPairwise)
            {
                Console.WriteLine("pairwise coprime");
                return;
            }

            var gcd = A.Aggregate((x, y) => GCD(x, y));
            Console.WriteLine(gcd == 1 ? "setwise coprime" : "not coprime");

            // var tmp = A[0];
            // for (var i = 1; i < N; i++)
            // {
            //     tmp = GCD(tmp, A[i]);
            // }

            // if (tmp != 1)
            // {
            //     Console.WriteLine("not coprime");
            //     return;
            // }

            // var isPairwise = true;
            // var primes = new HashSet<long>();
            // for (var i = 0; i < N && isPairwise; i++)
            // {
            //     tmp = A[i];
            //     if (primes.Contains(tmp))
            //     {
            //         isPairwise = false;
            //         break;
            //     }
            //     var max = (long)Math.Sqrt(A[i]);
            //     var p = 2;
            //     while (p <= max)
            //     {
            //         if (tmp % p == 0)
            //         {
            //             if (primes.Contains(p))
            //             {
            //                 isPairwise = false;
            //                 break;
            //             }
            //             primes.Add(p);
            //             while (tmp % p == 0)
            //             {
            //                 tmp /= p;
            //             }
            //         }
            //         p++;
            //     }
            //     if (tmp > 1)
            //     {
            //         if (primes.Contains(tmp))
            //         {
            //             isPairwise = false;
            //             break;
            //         }
            //         primes.Add(tmp);
            //     }
            // }

            // Console.WriteLine(isPairwise ? "pairwise coprime" : "setwise coprime");
        }

        static long GCD(long a, long b) => b == 0 ? a : GCD(b, a % b);

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
