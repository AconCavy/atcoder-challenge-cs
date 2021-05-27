using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5 3
2 1
3 2
1 5
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 2
2 1
2 3
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"8 10
3 8
2 1
4 6
3 6
4 1
5 8
2 4
7 6
7 2
3 1
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
