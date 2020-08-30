using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
5 8 2";
            var output = @"4";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"9
1 2 3 4 5 6 7 8 9";
            var output = @"8";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
