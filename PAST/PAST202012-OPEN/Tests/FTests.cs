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
            const string input = @"4 2
1 2 3
1 2 4
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6 7
1 2 5
2 3 5
2 4 5
1 2 3
4 5 6
2 5 6
1 3 5
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 1
1 2 3
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
