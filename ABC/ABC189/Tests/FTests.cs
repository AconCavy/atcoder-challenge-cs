using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-3;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 2 0

";
            const string output = @"1.5000
";
            Tester.InOutTest(Tasks.F.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 2 1
1
";
            const string output = @"2.0000
";
            Tester.InOutTest(Tasks.F.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"100 6 10
11 12 13 14 15 16 17 18 19 20
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.F.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"100000 2 2
2997 92458
";
            const string output = @"201932.2222
";
            Tester.InOutTest(Tasks.F.Solve, input, output, RelativeError);
        }
    }
}
