using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"needed";
            var output = @"2 3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"atcoder";
            var output = @"-1 -1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
