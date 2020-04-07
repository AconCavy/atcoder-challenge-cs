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
            var input = "2 5\n1 WA\n1 AC\n2 WA\n2 AC\n2 WA\n";
            var output = "2 2\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "100000 3\n7777 AC\n7777 AC\n7777 AC\n";
            var output = "1 0\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "6 0\n";
            var output = "0 0\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
