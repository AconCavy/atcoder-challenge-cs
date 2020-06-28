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
            var ABC = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = 0;
            if (ABC[0] == ABC[1]) answer = ABC[2];
            if (ABC[0] == ABC[2]) answer = ABC[1];
            if (ABC[1] == ABC[2]) answer = ABC[0];
            Console.WriteLine(answer);
        }
    }
}
