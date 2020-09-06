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
            var answer = "UNRESTORABLE";
            if (s.Length < t.Length)
            {
                Console.WriteLine(answer);
                return;
            }
            for (var i = s.Length - 1; i >= t.Length - 1; i--)
            {
                var tmp = s.ToCharArray();
                var ok = true;
                if (s[i] == t[t.Length - 1] || s[i] == '?')
                {
                    for (var j = 0; j < t.Length; j++)
                    {
                        if (s[i - j] != t[t.Length - 1 - j] && s[i - j] != '?')
                        {
                            ok = false;
                            break;
                        }
                    }
                }
                else
                {
                    ok = false;
                }

                if (ok)
                {
                    for (var j = 0; j < t.Length; j++)
                    {
                        tmp[i - j] = t[t.Length - 1 - j];
                    }
                    answer = new string(tmp);
                    answer = answer.Replace("?", "a");
                    break;
                }
            }
            Console.WriteLine(answer);
        }
    }
}
