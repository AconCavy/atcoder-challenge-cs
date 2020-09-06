using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1 1 1";
            var output = @"100";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"53 82 49";
            var output = @"1.674364";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -6);
        }
    }
}
