using Microsoft.VisualStudio.TestTools.UnitTesting;
using D;

namespace Tests
{
    [TestClass]
    public class TestD
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
011";
            var output = @"2
1
1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"23
00110111001011011001110";
            var output = @"2
1
2
2
1
2
2
2
2
2
2
2
2
2
2
2
2
2
2
2
2
1
3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
