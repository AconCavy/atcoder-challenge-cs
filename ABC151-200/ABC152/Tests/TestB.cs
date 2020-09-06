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
            var input = "4 3\n";
            var output = "3333\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "7 7\n";
            var output = "7777777\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
