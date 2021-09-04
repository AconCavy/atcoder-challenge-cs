using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5 3
2 2
1 3
2 2
";
            const string output = @"5
3
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 3
1 2
1 4
2 3
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"100 10
1 31
2 41
1 59
2 26
1 53
2 58
1 97
2 93
1 23
2 84
";
            const string output = @"69
31
6
38
38
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
