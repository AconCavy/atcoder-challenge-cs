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
            var input = @"10 0 15 0 30";
            var output = @"270";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10 0 12 0 120";
            var output = @"0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

    }
}
