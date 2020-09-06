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
            var input = "2 50\n6 10\n";
            var output = "2\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "3 100\n14 22 40\n";
            var output = "0\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "5 1000000000\n6 6 2 6 2\n";
            var output = "166666667\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
