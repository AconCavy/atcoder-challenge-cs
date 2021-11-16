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
1 10 15
1 11 12
1 14 16
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
1 20 22
1 22 24
2 0 2
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5
2 0 24
1 0 10
3 0 1
1 12 23
3 22 24
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
