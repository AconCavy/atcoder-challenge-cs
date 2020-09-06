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
            var input = "5 7 9\n";
            var output = "win\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "13 7 2\n";
            var output = "bust\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
