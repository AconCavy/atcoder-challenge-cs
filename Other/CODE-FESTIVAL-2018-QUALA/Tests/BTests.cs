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
            const string input = @"5 2 6 7
2 3
3 4
";
            const string output = @"32
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 3 20 30
1 6
2 7
3 10
";
            const string output = @"200
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"100 5 12 34
6 8
81 81
26 26
90 91
49 50
";
            const string output = @"3202
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
