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
            var input = "3\n1 3 2\n3 1 2\n";
            var output = "3\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "8\n7 3 5 4 2 1 6 8\n3 8 2 5 4 6 7 1\n";
            var output = "17517\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "3\n1 2 3\n1 2 3\n";
            var output = "0\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
