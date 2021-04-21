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
            const string input = @"4 4
2 5
....
.SS.
..S.
....
";
            const string output = @"12
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 2
4 7
.S
S.
";
            const string output = @"11
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4 8
9 13
.SS.....
.SS.....
.SS.....
.SS.....
";
            const string output = @"49
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
