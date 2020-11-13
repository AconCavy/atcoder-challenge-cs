using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2
2 -1";
            const string output = @"3
2.236067977499790
2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output, -9);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"10
3 -1 -4 1 -5 9 2 -6 5 -3";
            const string output = @"39
14.387494569938159
9";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output, -9);
        }
    }
}
