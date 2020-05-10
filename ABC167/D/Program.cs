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
            var nk = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var towns = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var trees = towns.Select(x => new Node()).ToArray();
            for (var i = 0; i < trees.Length; i++)
            {
                trees[i].Index = i;
                trees[i].Next = trees[towns[i] - 1];
            }
            var counter = new int[trees.Length];
            var index = 0;
            while (true)
            {
                counter[index]++;
                if (counter[index] == 3) break;
                index = trees[index].Next.Index;
            }
            var loopCount = 0L;
            var stepCount = 0L;
            for (var i = 0; i < counter.Length; i++)
            {
                if (counter[i] >= 2) loopCount++;
                if (counter[i] > 0) stepCount++;
            }

            var end = 0L;
            if (nk[1] < stepCount)
            {
                end = nk[1];
                index = 0;
            }
            else
            {
                end = (nk[1] - stepCount) % loopCount;
            }
            var answer = 0L;
            for (var i = 0; i <= end; i++)
            {
                answer = trees[index].Index + 1;
                index = trees[index].Next.Index;
            }
            Console.WriteLine(answer);
        }

        public class Node
        {
            public int Index { get; set; }
            public Node Next { get; set; }
        }
    }
}
