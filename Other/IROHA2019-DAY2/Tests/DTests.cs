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
            const string input = @"5 10
4 1 45
4 2 48
5 3 72
1 4 93
5 1 32
1 3 56
5 1 38
5 4 41
5 2 6
5 1 19
";
            const string output = @"2
3
4
6
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 8
1 4 72
2 1 52
1 3 10
5 3 7
3 4 37
3 2 47
4 1 82
5 3 57
";
            const string output = @"2
6
7
8
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
