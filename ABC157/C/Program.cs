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
            var digits = new int[nm[0]];
            var checker = new bool[nm[0]];
            for (var i = 0; i < nm[1]; i++)
            {
                var sc = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                if (checker[sc[0] - 1] && digits[sc[0] - 1] != sc[1])
                {
                    Console.WriteLine(-1);
                    return;
                }
                digits[sc[0] - 1] = sc[1];
                checker[sc[0] - 1] = true;
            }

            if (digits[0] == 0 && nm[0] != 1)
            {
                if (checker[0])
                {
                    Console.WriteLine(-1);
                    return;
                }
                else
                {
                    digits[0] = 1;
                }
            }

            Console.WriteLine(int.Parse(string.Join("", digits)));
        }
    }
}
