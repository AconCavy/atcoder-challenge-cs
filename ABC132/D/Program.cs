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
            var nk = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var p = (long)Math.Pow(10, 9) + 7;
            for (var i = 1; i <= nk[1]; i++)
            {
                var continuousBlue = CombinationCount(nk[0] - nk[1] + 1, i, p);
                var modBlue = CombinationCount(nk[1] - 1, i - 1, p);
                Console.WriteLine((continuousBlue * modBlue) % p);
            }
        }

        static long PermutationCount(long n, long k, long mod)
        {
            if (n < k) return 0;
            var result = 1L;
            for (var i = 0; i < k; i++)
                result = (result * (n - i) % mod) % mod;
            return result;
        }

        static long CombinationCount(long n, long k, long mod)
        {
            if (n < k) return 0;
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
