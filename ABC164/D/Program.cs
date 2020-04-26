using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            var s = Console.ReadLine().Trim().ToCharArray().Select(x => double.Parse(x.ToString())).ToArray();
            var count = 0L;
            for (var i = 0; i < s.Length - 3; i++)
            {
                var val = 100 * s[i] + 10 * s[i + 1] + s[i + 2];
                for (var j = 3; i + j < s.Length; j++)
                {
                    val = ((val * 10) % 2019 + s[i + j]) % 2019;
                    if (val == 0) count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
