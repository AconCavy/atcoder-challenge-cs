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
            var input = @"3 4 9 0";
            var output = @"5.00000000000000000000";
            Tester.InOutTest(() => Program.Solve(), input, output, -9);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 4 10 40";
            var output = @"4.56425719433005567605";
            Tester.InOutTest(() => Program.Solve(), input, output, -9);
        }
    }
}
