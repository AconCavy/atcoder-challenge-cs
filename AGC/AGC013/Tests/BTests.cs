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
            const string input = @"5 6
1 3
1 4
2 3
1 5
3 5
2 4
";
            const string output = @"4
2 3 1 4
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"7 8
1 2
2 3
3 4
4 5
5 6
6 7
3 5
2 6
";
            const string output = @"7
1 2 3 4 5 6 7
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"12 18
3 5
4 12
9 11
1 10
2 5
6 10
8 11
1 3
4 10
2 4
3 7
2 10
3 12
3 9
1 7
2 3
2 11
10 11
";
            const string output = @"8
12 4 2 5 3 9 11 8
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
