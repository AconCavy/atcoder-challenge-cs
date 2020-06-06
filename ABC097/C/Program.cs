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
            var s = Console.ReadLine();
            var k = int.Parse(Console.ReadLine());
            var hash = new HashSet<string>();
            for (var i = 0; i < s.Length; i++)
            {
                for (var j = i; j < s.Length; j++)
                {
                    var length = j - i + 1;
                    if (length <= k) hash.Add(s.Substring(i, length));
                }
            }
            var ss = hash.ToList();
            ss.Sort(StringComparer.Ordinal);
            Console.WriteLine(ss[k - 1]);
        }
    }
}
