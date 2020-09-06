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
            var k = long.Parse(Console.ReadLine());
            var not1 = '1';
            var index = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] != '1')
                {
                    not1 = s[i];
                    index = i + 1;
                    break;
                }
            }
            Console.WriteLine(k < index ? '1' : not1);
        }
    }
}
