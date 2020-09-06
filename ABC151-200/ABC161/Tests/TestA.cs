using Microsoft.VisualStudio.TestTools.UnitTesting;
using A;

namespace Tests
{
    [TestClass]
    public class TestA
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = "1 2 3\n";
            var output = "3 1 2\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "100 100 100\n";
            var output = "100 100 100\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "41 59 31\n";
            var output = "31 41 59\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
