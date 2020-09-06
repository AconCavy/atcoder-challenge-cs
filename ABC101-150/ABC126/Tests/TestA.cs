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
            var input = @"3 1
ABC";
            var output = @"aBC";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 3
CABA";
            var output = @"CAbA";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
