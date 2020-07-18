using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class A
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
            var AB = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (A, B) = (AB[0], AB[1]);
            if (A == 1) A += 13;
            if (B == 1) B += 13;
            var answer = "Draw";
            if (A > B) answer = "Alice";
            if (A < B) answer = "Bob";
            Console.WriteLine(answer);
        }
    }
}
