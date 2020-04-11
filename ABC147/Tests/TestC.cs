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
            var input = "3\n1\n2 1\n1\n1 1\n1\n2 0\n";
            var output = "2\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "3\n2\n2 1\n3 0\n2\n3 1\n1 0\n2\n1 1\n2 0\n";
            var output = "0\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "2\n1\n2 0\n1\n1 0\n";
            var output = "1\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
