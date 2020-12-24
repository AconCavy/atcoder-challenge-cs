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
            const string input = @"3 2 1
9 5
3 1
8 9";
            const string output = @"5";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 4 100
999 999 999 999
999 999 999 999
999 999 999 999
999 999 999 999";
            const string output = @"999";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3 4 5
700 198 700 198
198 700 198 700
700 198 700 198";
            const string output = @"198";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
