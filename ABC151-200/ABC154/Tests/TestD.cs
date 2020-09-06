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
            var input = "5 3\n1 2 2 4 5\n";
            var output = "7\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "4 1\n6 6 6 6\n";
            var output = "3.5\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "10 4\n17 13 13 12 15 20 10 13 17 11\n";
            var output = "32\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
