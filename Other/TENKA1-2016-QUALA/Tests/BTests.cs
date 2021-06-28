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
            const string input = @"3 2
0
0
1 5
2 10
";
            const string output = @"15
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 3
0
1
0
1
2 5
3 3
4 7
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7 4
0
0
2
2
3
3
1 3
4 2
5 8
6 6
";
            const string output = @"11
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
