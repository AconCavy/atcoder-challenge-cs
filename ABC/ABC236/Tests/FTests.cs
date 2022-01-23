using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
4 5 3
";
            const string output = @"7
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
9 7 9 7 10 4 3 9 4 8 10 5 6 3 8
";
            const string output = @"15
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
