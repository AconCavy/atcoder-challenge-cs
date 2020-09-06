using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            var k = int.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            for (var i = 1; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            for (var i = 1; i <= k; i++)
            {
                var x = queue.Dequeue();
                if (i == k) Console.WriteLine(x);

                if (x % 10 != 0) queue.Enqueue((x * 10) + (x % 10) - 1);
                queue.Enqueue((x * 10) + (x % 10));
                if (x % 10 != 9) queue.Enqueue((x * 10) + (x % 10) + 1);
            }
        }
    }
}
