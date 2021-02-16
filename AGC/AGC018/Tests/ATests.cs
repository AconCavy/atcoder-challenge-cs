using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 7
9 3 4
";
            const string output = @"POSSIBLE
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 5
6 9 3
";
            const string output = @"IMPOSSIBLE
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4 11
11 3 7 15
";
            const string output = @"POSSIBLE
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"5 12
10 2 8 6 4
";
            const string output = @"IMPOSSIBLE
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
