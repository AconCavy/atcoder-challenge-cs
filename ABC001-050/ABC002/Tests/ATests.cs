using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"10 11";
            var output = @"11";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"100000000 10000000";
            var output = @"100000000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
