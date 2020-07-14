using Microsoft.VisualStudio.TestTools.UnitTesting;
using I;

namespace Tests
{
    [TestClass]
    public class TestI
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
0.30 0.60 0.80";
            var output = @"0.612";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1
0.50";
            var output = @"0.5";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5
0.42 0.01 0.42 0.99 0.42";
            var output = @"0.3821815872";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
