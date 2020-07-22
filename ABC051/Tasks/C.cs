using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var xy = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (sx, sy, tx, ty) = (xy[0], xy[1], xy[2], xy[3]);
            var answer = "";
            var dx = tx - sx;
            var dy = ty - sy;
            answer += new string(Enumerable.Repeat('U', dy).ToArray());
            answer += new string(Enumerable.Repeat('R', dx).ToArray());
            answer += new string(Enumerable.Repeat('D', dy).ToArray());
            answer += new string(Enumerable.Repeat('L', dx).ToArray());
            answer += "L";
            answer += new string(Enumerable.Repeat('U', dy + 1).ToArray());
            answer += new string(Enumerable.Repeat('R', dx + 1).ToArray());
            answer += "D";
            answer += "R";
            answer += new string(Enumerable.Repeat('D', dy + 1).ToArray());
            answer += new string(Enumerable.Repeat('L', dx + 1).ToArray());
            answer += "U";

            Console.WriteLine(answer);
        }
    }
}
