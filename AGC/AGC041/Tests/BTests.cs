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
            const string input = @"6 1 2 2
2 1 1 3 0 2
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6 1 5 2
2 1 1 3 0 2
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 4 8 5
7 2 3 6 1 6 5 4 6 5
";
            const string output = @"8
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
