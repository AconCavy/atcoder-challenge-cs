using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            var s = Console.ReadLine();
            var q = int.Parse(Console.ReadLine());
            var rightBuilder = new StringBuilder(s, q);
            var leftBuilder = new StringBuilder(q);
            var isReverse = false;

            for (var i = 0; i < q; i++)
            {
                var query = Console.ReadLine().Trim().Split(' ');
                if (query[0] == "1")
                {
                    isReverse = !isReverse;
                }
                else if (query[0] == "2")
                {
                    if (query[1] == "1")
                    {
                        if (isReverse) rightBuilder.Append(query[2]);
                        else leftBuilder.Append(query[2]);

                    }
                    else if (query[1] == "2")
                    {
                        if (isReverse) leftBuilder.Append(query[2]);
                        else rightBuilder.Append(query[2]);
                    }
                }
            }
            var right = rightBuilder.ToString();
            var left = leftBuilder.ToString();
            var result = isReverse ? Reverse(right) + left : Reverse(left) + right;
            Console.WriteLine(result);
        }

        static string Reverse(string str)
        {
            var chars = str.ToCharArray();
            var length = chars.Length;
            for (var i = 0; i < length / 2; i++)
            {
                var tmp = chars[i];
                chars[i] = chars[length - i - 1];
                chars[length - i - 1] = tmp;
            }
            return new string(chars);
        }

    }
}
