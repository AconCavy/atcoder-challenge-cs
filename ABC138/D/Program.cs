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
            var nq = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var nodes = new Node[nq[0]];
            for (var i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new Node();
            }
            nodes[0].IsRoot = true;
            nodes[1].Depth = 1;

            var edges = new Tuple<int, int>[nq[0] - 1];
            for (var i = 0; i < edges.Length; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                edges[i] = new Tuple<int, int>(ab[0], ab[1]);
            }
            edges = edges.OrderBy(x => x.Item1).ToArray();
            for (var i = 0; i < edges.Length; i++)
            {
                var nodeA = nodes[edges[i].Item1 - 1];
                var nodeB = nodes[edges[i].Item2 - 1];
                if (nodeB.Parent == null && !nodeB.IsRoot)
                {
                    nodeB.Parent = nodeA;
                    nodeB.Depth = nodeA.Depth + 1;
                }
                else
                {
                    nodeA.Parent = nodeB;
                    nodeA.Depth = nodeB.Depth + 1;
                }
            }
            for (var i = 0; i < nq[1]; i++)
            {
                var px = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
                nodes[px[0] - 1].Count += px[1];
            }

            var tmpNodes = nodes.OrderBy(x => x.Depth).ToArray();
            for (var i = 0; i < tmpNodes.Length; i++)
            {
                tmpNodes[i].Count += tmpNodes[i].Parent?.Count ?? 0;
            }
            Console.WriteLine(string.Join(" ", nodes.Select(x => x.Count)));
        }
    }

    public class Node
    {
        public bool IsRoot { get; set; }
        public long Count { get; set; }
        public Node Parent { get; set; }
        public long Depth { get; set; }
    }
}
