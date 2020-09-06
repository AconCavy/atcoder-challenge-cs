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
            var d = int.Parse(Console.ReadLine());
            var diff = 25 - d;
            var answer = "Christmas";
            for (var i = 0; i < diff; i++)
            {
                answer += " Eve";
            }
            Console.WriteLine(answer);
        }
    }
}
