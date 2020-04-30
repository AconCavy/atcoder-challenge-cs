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
            var count = 0L;
            var switches = new int[nm[1]][];
            for (var i = 0; i < switches.Length; i++)
            {
                switches[i] = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x) - 1).ToArray();
            }
            var p = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            for (var bit = 0; bit < (1 << nm[0]); bit++)
            {
                var isValid = true;
                for (var j = 0; j < switches.Length; j++)
                {
                    var tmp = 0;
                    var lights = switches[j];
                    for (var k = 1; k < lights.Length; k++)
                    {
                        if (((bit >> lights[k]) & 1) == 1) tmp++;
                    }
                    if (tmp % 2 != p[j]) isValid = false;
                }
                if (isValid) count++;
            }
            Console.WriteLine(count);
        }
    }
}
