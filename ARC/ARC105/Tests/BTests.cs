using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3
2 6 6";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"15
546 3192 1932 630 2100 4116 3906 3234 1302 1806 3528 3780 252 1008 588";
            const string output = @"42";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"2
1 100";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
