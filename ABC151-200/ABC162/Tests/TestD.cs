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
            var input = @"4
RRGB";
            var output = @"1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"39
RBRBGRBGGBBRRGBBRRRBGGBRBGBRBGBRBBBGBBB";
            var output = @"1800";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
