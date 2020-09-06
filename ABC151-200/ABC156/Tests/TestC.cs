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
            var input = "2\n1 4\n";
            var output = "5\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "7\n14 14 2 13 56 2 37\n";
            var output = "2354\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
