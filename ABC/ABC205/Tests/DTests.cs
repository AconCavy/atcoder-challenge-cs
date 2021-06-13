using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 3
3 5 6 7
2
5
3
";
            const string output = @"2
9
4
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 2
1 2 3 4 5
1
10
";
            const string output = @"6
15
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
