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
            const string input = @"3 3
1 2
1 3
2 3
";
            const string output = @"1
2
1
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 4
1 2
2 3
2 4
3 4
";
            const string output = @"-1
2
3
2
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 10
1 2
1 4
1 5
2 1
2 3
3 1
3 2
3 5
4 2
4 3
";
            const string output = @"1
1
3
1
1
1
1
1
1
1
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"4 1
1 2
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
