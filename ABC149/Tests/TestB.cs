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
            var input = "2 3 3\n";
            var output = "0 2\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "500000000000 500000000000 1000000000000\n";
            var output = "0 0\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
