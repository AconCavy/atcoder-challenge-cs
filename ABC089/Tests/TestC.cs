using Microsoft.VisualStudio.TestTools.UnitTesting;
using C;

namespace Tests
{
    [TestClass]
    public class TestC
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
MASHIKE
RUMOI
OBIRA
HABORO
HOROKANAI";
            var output = @"2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
ZZ
ZZZ
Z
ZZZZZZZZZZ";
            var output = @"0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5
CHOKUDAI
RNG
MAKOTO
AOKI
RINGO";
            var output = @"7";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
