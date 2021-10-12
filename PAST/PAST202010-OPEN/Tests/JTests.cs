using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class JTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 2
10 10 10
ABA
1 2 15
2 3 5
";
            const string output = @"15
";
            Tester.InOutTest(Tasks.J.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 2
10 1000000000 10
ABC
1 2 1000000000
2 3 1000000000
";
            const string output = @"20
";
            Tester.InOutTest(Tasks.J.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 6
5 10 15
ABCBC
5 4 4
3 5 2
1 3 7
3 4 1
4 2 1
2 3 3
";
            const string output = @"8
";
            Tester.InOutTest(Tasks.J.Solve, input, output);
        }
    }
}
