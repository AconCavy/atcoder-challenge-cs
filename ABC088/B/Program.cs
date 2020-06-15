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
            var N = int.Parse(Console.ReadLine());
            var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var queue = new Queue<int>(ai.OrderByDescending(x => x));
            var alice = 0;
            var bob = 0;
            var flag = true;
            while (queue.Any())
            {
                if (flag) alice += queue.Dequeue();
                else bob += queue.Dequeue();
                flag = !flag;
            }
            Console.WriteLine(Math.Abs(alice - bob));
        }
    }
}
