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
            const string input = @"4 3
1 2 3
4 5 6
7 8 9
10 11 12
";
            const string output = @"1 4 7 10
2 5 8 11
3 6 9 12
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 2
1000000000 1000000000
1000000000 1000000000
";
            const string output = @"1000000000 1000000000
1000000000 1000000000
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
