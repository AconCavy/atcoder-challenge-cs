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
            const string input = @"1 2
10 10
12 4
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"100 1
101 101
102 1
";
            const string output = @"infinity
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"12000 15700
3390000000 3810000000
5550000000 2130000000
";
            const string output = @"113
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
