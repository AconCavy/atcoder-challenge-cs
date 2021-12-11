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
            const string input = @"3
50 100 150
1 3 2
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
123456789 123456 123
987 987654 987654321
";
            const string output = @"6
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
3 1 4 1 5 9 2 6 5 3
2 7 1 8 2 8 1 8 2 8
";
            const string output = @"37
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
