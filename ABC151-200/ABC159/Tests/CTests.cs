using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3";
            var output = @"1.000000000000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"999";
            var output = @"36926037.000000000000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -6);
        }
    }
}
