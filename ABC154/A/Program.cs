using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
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
            var sn = Console.ReadLine().Trim().Split(' ');
            var nn = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var str = Console.ReadLine();

            if(str == sn[0]) nn[0]--;
            else nn[1]--; 
            Console.WriteLine($"{nn[0]} {nn[1]}");
        }
    }
}
