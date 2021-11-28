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
            const string input = @"4 5 6 5
1 1 6
1 3 3
2 2 4
2 4 2
1 1 2
";
            const string output = @"0 8 3 3 0 0
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1000000000 1000000000 3 5
1 1 2
1 2 2
1 3 2
1 4 2
1 5 2
";
            const string output = @"0 5000000000 0
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
