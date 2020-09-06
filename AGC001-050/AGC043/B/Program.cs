using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
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
            var n = int.Parse(Console.ReadLine());
            var ai = Console.ReadLine().Trim().Select(x => x - '1').ToArray();
            var isContain1 = ai.Contains(1);
            if (!isContain1) ai = ai.Select(x => x /= 2).ToArray();
            var isOdd = IsOdd(ai);

            if (isContain1) Console.WriteLine(isOdd ? 1 : 0);
            else Console.WriteLine(isOdd ? 2 : 0);
        }

        static bool IsOdd(int[] items)
        {
            var binCoef = new int[items.Length];
            var n = items.Length - 1;
            for (int i = 0, j = binCoef.Length - 1; i < j; i++, j--)
            {
                binCoef[i] = binCoef[j] = n == (i | (n - i)) ? 1 : 0;
            }

            var tmp = 0;
            for (var i = 0; i < binCoef.Length; i++)
            {
                if (binCoef[i] % 2 == 1 && items[i] % 2 == 1) tmp++;
            }
            return tmp % 2 == 1;
        }
    }
}
