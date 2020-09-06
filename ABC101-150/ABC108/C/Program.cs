using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var nk = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var n = nk[0];
            var k = nk[1];
            var tmp = n / k;
            var answer = tmp * tmp * tmp;
            if (k % 2 == 0)
            {
                if (tmp * k + k / 2 > n) tmp--;
                tmp++;
                answer += tmp * tmp * tmp;
            }
            Console.WriteLine(answer);
        }
    }
}
