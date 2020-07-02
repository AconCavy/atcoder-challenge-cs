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
            var S = Console.ReadLine();
            var distinct = S.Distinct().ToArray();
            Array.Sort(distinct);
            var all = "abcdefghijklmnopqrstuvwxyz";
            var reference = all.ToCharArray();
            var answer = reference.Except(distinct).ToArray();
            Console.WriteLine(answer.Any() ? answer[0].ToString() : "None");
        }
    }
}
