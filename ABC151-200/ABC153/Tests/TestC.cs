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
            var input = "3 1\n4 1 5\n";
            var output = "5\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "8 9\n7 9 3 2 3 8 4 6\n";
            var output = "0\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "3 0\n1000000000 1000000000 1000000000\n";
            var output = "3000000000\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
