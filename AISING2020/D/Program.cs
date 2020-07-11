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
            var N = int.Parse(Console.ReadLine());
            var X = Console.ReadLine().Select(x => x == '1').ToArray();
            var defaultCount = X.Count(x => x);
            var memo = new int[N];
            for (var i = 1; i < N; i++)
            {
                memo[i] = i % PopCount(i);
            }

            var counts = new int[N];
            counts[0] = 1;
            for (var i = 1; i < N; i++)
            {
                counts[i] = counts[memo[i]] + 1;
            }

            Console.WriteLine(string.Join(" ", counts));
            for (var i = 0; i < N; i++)
            {
                var n = defaultCount;
                if (X[i]) n--;
                else n++;
                var tmp = X;
                tmp[i] = !tmp[i];
                var answer = 0;
                if (n != 0)
                {
                    var mod = GetVal(tmp, n);
                    answer = counts[mod];
                }
                Console.WriteLine(answer);
            }
        }

        private static int GetVal(bool[] n, int mod)
        {
            var ret = 0;
            var rev = n.Reverse().ToArray();
            for (var i = 0; i < rev.Length; i++)
            {
                if (rev[i])
                {
                    ret += Power(2, i, mod);
                    ret %= mod;
                }
            }
            return ret;
        }

        private static int PopCount(int n)
        {
            var i = 0;
            var count = 0;
            while ((1 << i) <= n)
            {
                if (((n >> i) & 1) == 1) count++;
                i++;
            }
            return count;
        }

        public static int Power(int x, int y, int mod)
        {
            var result = 1;
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
