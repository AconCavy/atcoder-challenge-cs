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
            var dpc = X.Count(x => x);
            var dnWhen0 = GetValue(X, dpc + 1);
            var dnWhen1 = GetValue(X, dpc - 1);
            var answer = new int[N];
            var memo = new int[N + 1];
            for (var i = 1; i < memo.Length; i++)
            {
                memo[i] = i % PopCount(i);
            }
            var counts = new int[N + 1];
            for (var i = 1; i < counts.Length; i++)
            {
                counts[i] = counts[memo[i]] + 1;
            }

            for (var i = 0; i < X.Length; i++)
            {
                var pc = dpc;
                var n = 0;
                pc += X[i] ? -1 : 1;
                if (pc <= 0) continue;
                var pow = Power(2, N - 1 - i, pc);
                if (X[i]) n = (pc + dnWhen1 - pow) % pc;
                else n = (dnWhen0 + pow) % pc;

                Console.WriteLine(counts[n] + 1);
            }
        }

        private static int GetValue(bool[] n, int mod)
        {
            var ret = 0;
            for (var i = 0; i < n.Length; i++)
            {
                if (n[n.Length - 1 - i])
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
