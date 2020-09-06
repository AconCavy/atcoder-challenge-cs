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
            var input = @"2 3
1 32
2 63
1 12";
            var output = @"000001000002
000002000001
000001000001";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 3
2 55
2 77
2 99";
            var output = @"000002000001
000002000002
000002000003";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
