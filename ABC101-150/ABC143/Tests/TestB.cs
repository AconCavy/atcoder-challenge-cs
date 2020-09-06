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
            var input = @"3
3 1 2";
            var output = @"11";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7
5 0 7 8 3 3 2";
            var output = @"312";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
