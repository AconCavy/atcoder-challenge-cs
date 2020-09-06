using Microsoft.VisualStudio.TestTools.UnitTesting;
using B;

namespace Tests
{
    [TestClass]
    public class TestB
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = "10\nZABCDBABCQ\n";
            var output = "2\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "19\nTHREEONEFOURONEFIVE\n";
            var output = "0\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "33\nABCCABCBABCCABACBCBBABCBCBCBCABCB\n";
            var output = "5\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
