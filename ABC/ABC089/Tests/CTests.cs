using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
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
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
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
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
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
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
