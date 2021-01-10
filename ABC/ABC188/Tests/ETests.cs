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
            const string input = @"4 3
2 3 1 5
2 4
1 2
1 3
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 5
13 8 3 15 18
2 4
1 2
4 5
2 3
1 3
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3 1
1 100 1
2 3
";
            const string output = @"-99
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
