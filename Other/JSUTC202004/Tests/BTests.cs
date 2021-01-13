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
            const string input = @"4
10 B
6 R
2 R
4 B
";
            const string output = @"2
6
4
10
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
5 B
7 B
";
            const string output = @"5
7
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
