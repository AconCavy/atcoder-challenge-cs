using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
2 3 7 9";
            var output = @"7";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"8
3 1 4 1 5 9 2 6";
            var output = @"8";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
