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
            var input = @"3
1
4
3";
            var output = @"4
3
4";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2
5
5";
            var output = @"5
5";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
