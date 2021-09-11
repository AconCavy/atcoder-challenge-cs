using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 5
1 2 1
1 3 1
1 4 1
3 2 2
4 2 2
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3
1 2 1
2 3 0
3 1 -1
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"2 3
1 2 -1
1 2 2
1 1 3
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
