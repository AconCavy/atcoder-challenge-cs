using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 2
2 1 2
5 2 3
";
            const string output = @"12
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 5
8 1 4
11 6 7
20 1 1
31 9 9
36 1 1
";
            const string output = @"113
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 10
76724435 3 4
118633459 1 2
288866156 6 9
470883673 6 10
521545097 2 4
827053186 1 1
856004743 2 4
873331881 1 1
909855542 6 10
916091889 8 9
";
            const string output = @"8003096514
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
