using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 3";
            var output = @"3333";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7 7";
            var output = @"7777777";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
