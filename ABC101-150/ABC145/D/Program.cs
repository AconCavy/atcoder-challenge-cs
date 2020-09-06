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
            var xy = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var p = (long)Math.Pow(10, 9) + 7;
            var step = (xy[0] + xy[1]);
            if ((step % 3) != 0)
            {
                Console.WriteLine(0);
                return;
            }
            var nm = step / 3;
            var n = xy[0] - nm;
            var m = xy[1] - nm;
            if (n < 0 || m < 0)
            {
                Console.WriteLine(0);
                return;
            }
            Console.WriteLine(CombinationCount((n + m), n, p));
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
            return (top * Inverse(bottom, mod)) % mod;
        }

        static long Inverse(long x, long mod)
        {
            return Power(x, mod - 2, mod);
        }

        static long Power(long x, long y, long mod)
        {
            long result = 1;
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
