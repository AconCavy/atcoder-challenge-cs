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
            var input = "5\n2 6 1 4 5\n";
            var output = "YES\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "6\n4 1 3 1 6 2\n";
            var output = "NO\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "2\n10000000 10000000\n";
            var output = "NO\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
