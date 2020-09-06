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
            var input = @"5";
            var output = @"11 31 41 61 71";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6";
            var output = @"11 31 41 61 71 101";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"8";
            var output = @"11 31 41 61 71 101 131 151";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
