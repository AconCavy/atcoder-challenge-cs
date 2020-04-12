using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public static class Tester
    {
        public static void InOutTest(Action action, string input, string output)
        {
            using var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            var b = new StringBuilder();
            using var sw = new StringWriter(b);
            Console.SetOut(sw);

            action();

            using var sr = new StringReader(b.ToString());
            var actual = sr.ReadToEnd().Replace("\r", "").Replace("\n", "").Replace(Environment.NewLine, "");
            var expected = output.Replace("\r", "").Replace("\n", "").Replace(Environment.NewLine, "");
            Assert.AreEqual(expected, actual);
        }
    }
}