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
            var input = @"3 3 1 1";
            var output = @"011
100
100";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1 5 2 0";
            var output = @"11000";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
