using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"11";
            var output = @"10";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"20200920";
            var output = @"1100144";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
