using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class C
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
            var A = new int[N + 1];
            Array.Fill(A, 1);

            foreach (var p in GetPrimes(N))
            {
                for (var i = (long)p; i <= N; i *= p)
                {
                    for (var j = i; j <= N; j += i)
                    {
                        A[j]++;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", A[1..]));
        }

        public static int[] GetPrimes(int value)
        {
            if (value < 2) return Array.Empty<int>();
            if (value == 2) return new[] { 2 };
            const int bit = 32;
            const int limit = 1024;
            value = (value + 1) / 2;
            var length = (value + bit) / bit;
            var sieve = length < limit ? stackalloc uint[length] : new uint[length];
            for (var i = value % bit; i < bit; i++) sieve[^1] |= 1U << i;
            for (var i = 1; i * i <= value;)
            {
                for (var j = i; j <= value; j += i * 2 + 1) sieve[j / bit] |= 1U << (j % bit);
                sieve[i / bit] &= ~(1U << (i % bit));
                do
                {
                    i++;
                } while (i * i <= value && ((sieve[i / bit] >> (i % bit)) & 1) == 1);
            }
            var count = bit * length;
            foreach (var flags in sieve) count -= BitOperations.PopCount(flags);
            var primes = count < limit ? stackalloc int[count] : new int[count];
            primes[0] = 2;
            var index = 1;
            for (var i = 1; index < count && i <= value; i++)
                if (((sieve[i / bit] >> (i % bit)) & 1U) == 0)
                    primes[index++] = i * 2 + 1;
            return primes.ToArray();
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
