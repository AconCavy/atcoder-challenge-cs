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
            var nab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var p = (long)Math.Pow(10, 9) + 7;
            var all = (PowWithMod(2, nab[0], p) - (1 % p)) % p;
            var combA = (PermutationCountWithMod(nab[0], nab[1], p) * PowWithMod(PermutationCountWithMod(nab[1], nab[1], p), p - 2, p)) % p;
            var combB = (PermutationCountWithMod(nab[0], nab[2], p) * PowWithMod(PermutationCountWithMod(nab[2], nab[2], p), p - 2, p)) % p;
            var result = (all - combA - combB + p) % p;
            Console.WriteLine(result);
        }

        static long PermutationCountWithMod(long n, long k, long mod)
        {
            if (n < k) throw new ArgumentException();
            var result = n % mod;
            for (var i = 1; i < k; i++)
                result *= ((n - i) % mod);
            return result % mod;
        }

        static long PowWithMod(long x, long n, long mod)
        {
            if (n == 1) return x % mod;
            if (n % 2 == 1) return ((x % mod) * PowWithMod(x, n - 1, mod)) % mod;
            var tmp = PowWithMod(x, n / 2, mod);
            return ((tmp % mod) * (tmp % mod)) % mod;
        }
    }
}
