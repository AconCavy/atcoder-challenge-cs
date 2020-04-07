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
            var nm = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var acNum = 0;
            var waNum = 0;
            var ac = new bool[nm[0]];
            var wa = new int[nm[0]];
            for (var i = 0; i < nm[1]; i++)
            {
                var ps = Console.ReadLine().Trim().Split(' ');
                var issue = int.Parse(ps[0]) - 1;
                var res = ps[1];
                if (ac[issue]) continue;
                if (res.Equals("AC"))
                {
                    ac[issue] = true;
                    acNum++;
                    waNum += wa[issue];
                }
                else
                {
                    wa[issue]++;
                }
            }
            Console.WriteLine($"{acNum} {waNum}");
        }
    }
}
