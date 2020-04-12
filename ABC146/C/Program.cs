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
            var abx = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            Func<long, long> getDigit = x => x.ToString().Length;
            Func<long, long> calcPrice = x => abx[0] * x + abx[1] * getDigit(x);
            var limit = (long)Math.Pow(10, 9);
            var checkNumber = limit;
            var max = limit;
            var min = 0L;
            var result = 0L;
            var checkedNumbers = new List<long>();

            while (min < max)
            {
                if (checkedNumbers.Contains(checkNumber)) break;
                var tmp = calcPrice(checkNumber);
                checkedNumbers.Add(checkNumber);
                if (tmp <= abx[2])
                {
                    result = Math.Max(result, checkNumber);
                    min = checkNumber;
                    checkNumber += (max - min) / 2;
                }
                else
                {
                    max = checkNumber;
                    checkNumber -= (max - min) / 2;
                }
            }
            Console.WriteLine(result);
        }
    }
}
