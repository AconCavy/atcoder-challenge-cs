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
            const string input = @"3 3 2
7 35 5
14 9 50
1 1 2 2
1 1 3 2
";
            const string output = @"-140
-115
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 5 5
1 6 15 15 7
14 11 11 5 14
3 5 5 5
2 3 3 4
1 5 3 5
4 3 4 4
2 2 4 3
";
            const string output = @"98
54
140
-90
0
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
