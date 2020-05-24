using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var t = Console.ReadLine();
            var dict1 = new Dictionary<char, char>();
            var dict2 = new Dictionary<char, char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (dict1.ContainsKey(s[i]))
                {
                    if (dict1[s[i]] != t[i])
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
                else
                {
                    dict1[s[i]] = t[i];
                }

                if (dict2.ContainsKey(t[i]))
                {
                    if (dict2[t[i]] != s[i])
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
                else
                {
                    dict2[t[i]] = s[i];
                }
            }
            Console.WriteLine("Yes");
        }
    }
}
