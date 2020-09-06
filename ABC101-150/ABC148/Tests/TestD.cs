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
            var input = "3\n2 1 2\n";
            var output = "1\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "3\n2 2 2\n";
            var output = "-1\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "10\n3 1 4 1 5 9 2 6 5 3\n";
            var output = "7\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = "1\n1\n";
            var output = "0\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
