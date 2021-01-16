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
            const string input = @"4 2
0 1 0 2
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 2
0 1 1 2 3
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"20 4
6 2 6 8 4 5 5 8 4 1 7 8 0 3 6 1 1 8 3 0
";
            const string output = @"11
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
