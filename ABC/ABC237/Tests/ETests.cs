using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 4
10 8 12 5
1 2
1 3
2 3
3 4
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 1
0 10
1 2
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
