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
            var input = @"3 10";
            var output = @"0.145833333333";
            Tester.InOutTest(() => Program.Solve(), input, output, -9);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"100000 5";
            var output = @"0.999973749998";
            Tester.InOutTest(() => Program.Solve(), input, output, -9);
        }
    }
}
