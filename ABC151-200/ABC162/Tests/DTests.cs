using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4
RRGB";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"39
RBRBGRBGGBBRRGBBRRRBGGBRBGBRBGBRBBBGBBB";
            const string output = @"1800";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
