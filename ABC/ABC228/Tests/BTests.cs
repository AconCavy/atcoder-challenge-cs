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
3 1 1 2
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"20 12
7 11 10 1 7 20 14 2 17 3 2 5 19 20 8 14 18 2 10 10
";
            const string output = @"7
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
