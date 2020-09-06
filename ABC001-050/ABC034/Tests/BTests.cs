using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"100";
            var output = @"99";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"123456789";
            var output = @"123456790";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
