using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class JTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3
1 1 1
";
            const string output = @"5.5
";
            Tester.InOutTest(Tasks.J.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
3
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.J.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"2
1 2
";
            const string output = @"4.5
";
            Tester.InOutTest(Tasks.J.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"10
1 3 2 3 3 2 3 2 1 3
";
            const string output = @"54.48064457488221
";
            Tester.InOutTest(Tasks.J.Solve, input, output, RelativeError);
        }
    }
}
