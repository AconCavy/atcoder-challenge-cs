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
            var N = int.Parse(Console.ReadLine());
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var n4 = 0;
            var n2 = 0;
            var odd = 0;
            for (var i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 1)
                {
                    odd++;
                }
                else
                {
                    var tmp = A[i] / 2;
                    if (tmp % 2 == 1) n2++;
                    else n4++;
                }
            }
            if (n2 > 0) odd++;
            Console.WriteLine(n4 >= odd - 1 ? "Yes" : "No");
        }
    }
}
