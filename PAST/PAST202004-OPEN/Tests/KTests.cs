using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class KTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3
))(
3 5 7
2 6 5
";
            const string output = @"8
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
(
10
20
";
            const string output = @"20
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
))())((()(
13 18 17 3 20 20 6 14 14 2
20 1 19 5 2 19 2 19 9 4
";
            const string output = @"18
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"4
()()
17 8 3 19
5 3 16 3
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }
    }
}
