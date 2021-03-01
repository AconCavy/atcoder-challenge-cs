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
            const string input = @"3
3
2
5
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"15
3
1
4
1
5
9
2
6
5
3
5
8
9
7
9
";
            const string output = @"18
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
