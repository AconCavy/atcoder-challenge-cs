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
            var input = "a\n4\n2 1 p\n1\n2 2 c\n1\n";
            var output = "cpa\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "a\n6\n2 2 a\n2 1 b\n1\n2 2 c\n1\n1\n";
            var output = "aabc\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "y\n1\n2 1 x\n";
            var output = "xy\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
