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
            var input = "5 10 7\n8 10 3 6\n";
            var output = "8\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "4 100 60\n100 100 100\n";
            var output = "0\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "4 100 60\n0 0 0\n";
            var output = "-1\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
