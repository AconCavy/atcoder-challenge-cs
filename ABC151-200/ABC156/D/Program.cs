using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
{
    public class Program
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
            var nab = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var p = (long)Math.Pow(10, 9) + 7;
            var all = Power(2, nab[0], p);
            var combA = CombinationCount(nab[0], nab[1], p);
            var combB = CombinationCount(nab[0], nab[2], p);
            var result = (all - combA - combB - 1) % p;
            if (result < 0) result += p;
            Console.WriteLine(result);
        }

        static long PermutationCount(long n, long k, long mod)
        {
            if (n < k) throw new ArgumentException();
            var result = 1L;
            for (var i = 0; i < k; i++)
                result = (result * (n - i) % mod) % mod;
            return result;
        }

        static long CombinationCount(long n, long k, long mod)
        {
            if (n < k) throw new ArgumentException();
            k = Math.Min(k, n - k);
            var top = PermutationCount(n, k, mod);
            var bottom = PermutationCount(k, k, mod);
            return (top * Power(bottom, mod - 2, mod)) % mod;
        }

        static long Power(long x, long y, long mod)
        {
            var result = 1L;
            while (y > 0)
            {
                if ((y & 1) == 1) result = ((result % mod) * (x % mod)) % mod;
                x = ((x % mod) * (x % mod)) % mod;
                y >>= 1;
            }
            return result;
        }
    }
}
