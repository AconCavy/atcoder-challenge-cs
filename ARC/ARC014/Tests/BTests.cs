using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
ab
ba
ab
cb";
            const string output = @"LOSE";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
atcoder
redcoder
recorder";
            const string output = @"DRAW";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
