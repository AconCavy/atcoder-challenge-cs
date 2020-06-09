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
            var input = @"5
6 9 4 2 11";
            var output = @"11 6";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2
100 0";
            var output = @"100 0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
