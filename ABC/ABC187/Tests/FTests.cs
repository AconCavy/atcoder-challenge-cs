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
            const string input = @"3 2
1 2
1 3
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 6
1 2
1 3
1 4
2 3
2 4
3 4
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 11
9 10
2 10
8 9
3 4
5 8
1 8
5 6
2 5
3 6
6 9
1 9
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"18 0
";
            const string output = @"18
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
