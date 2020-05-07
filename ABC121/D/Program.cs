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
            var ab = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            Console.WriteLine(F(ab[0], ab[1]));
        }

        static long F(long l, long r)
        {
            if (l % 2 == 0)
            {
                var diff = r - l + 1;
                if (diff % 2 == 0) return F(l, r - 1) ^ r;
                else return ((diff / 2) % 2) ^ r;
            }
            else
            {
                return l ^ F(l + 1, r - 1) ^ r;
            }
        }
    }
}
