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
            const string input = @"3 3
1 2
6 1
4 1
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 10
92231 7
70370 1
4423 10
96481 4
69142 2
91784 3
16328 3
85936 8
93166 2
17394 1
";
            const string output = @"351801
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
