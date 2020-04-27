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
            var n = int.Parse(Console.ReadLine());
            var tasks = new List<Tuple<int, int>>();
            var timeSum = 0;
            var deadline = 0;
            for (var i = 0; i < n; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                tasks.Add(new Tuple<int, int>(ab[0], ab[1]));
                timeSum += ab[0];
                deadline = Math.Max(deadline, ab[1]);
            }
            if (timeSum > deadline)
            {
                Console.WriteLine("No");
                return;
            }
            var sortedTasks = tasks.OrderBy(x => x.Item2).ThenBy(x => x.Item1).ToList();
            timeSum = 0;
            deadline = 0;
            for (var i = 0; i < sortedTasks.Count; i++)
            {
                timeSum += sortedTasks[i].Item1;
                deadline = Math.Max(deadline, sortedTasks[i].Item2);
                if (timeSum > deadline)
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");
        }
    }
}
