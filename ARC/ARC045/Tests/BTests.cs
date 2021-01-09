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
            const string input = @"10 5
1 4
5 5
6 8
9 10
5 6
";
            const string output = @"2
2
5
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 6
1 1
1 1
2 2
2 2
3 3
3 3
";
            const string output = @"6
1
2
3
4
5
6
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 3
1 4
2 6
6 10
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
