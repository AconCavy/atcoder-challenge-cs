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
            var input = "2 2919\n";
            var output = "3719\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "22 3051\n";
            var output = "3051\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
