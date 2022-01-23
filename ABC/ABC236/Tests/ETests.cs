using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-3;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6
2 1 2 1 1 10
";
            const string output = @"4
2
";
            Tester.InOutTest(Tasks.E.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"7
3 1 4 1 5 9 2
";
            const string output = @"5.250000000
4
";
            Tester.InOutTest(Tasks.E.Solve, input, output, RelativeError);
        }
    }
}
