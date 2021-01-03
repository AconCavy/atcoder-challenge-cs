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
            const string input = @"8 7
1 2
2 3
2 4
5 6
6 7
6 8
7 8
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 1
1 2
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"11 11
1 2
1 3
2 4
3 5
4 6
5 7
6 8
7 9
8 10
9 11
10 11
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
