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
            var n = long.Parse(Console.ReadLine());
            var answer = 0L;
            var prime = new Prime(n);
            foreach (var p in prime.Factors.Keys)
            {
                var e = 1;
                while (true)
                {
                    var tmp = (long)Math.Pow(p, e++);
                    if (n % tmp == 0)
                    {
                        n /= tmp;
                        answer++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.WriteLine(answer);
        }
    }

    public class Prime
    {
        public Dictionary<long, long> Factors => new Dictionary<long, long>(_factors);
        private Dictionary<long, long> _factors;
        public Prime(long n)
        {
            _factors = new Dictionary<long, long>();

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

        public bool IsPrime(long n) => _factors.ContainsKey(n);
    }
}
