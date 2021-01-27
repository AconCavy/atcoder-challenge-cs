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
            const string input = @"3 1
1 2
1 3
2 3
";
            const string output = @"0
1
2
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6 3
2 1
2 3
4 1
4 2
6 1
2 6
4 6
6 5
";
            const string output = @"6
4
2
0
6
2
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
