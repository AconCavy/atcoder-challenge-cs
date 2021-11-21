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
            const string input = @"3
1 3
2 4
5 6
";
            const string output = @"0
0
1
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10
64 96
30 78
52 61
18 28
9 34
42 86
11 49
1 79
13 59
70 95
";
            const string output = @"0
0
2
18
18
18
18
18
18
21
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
