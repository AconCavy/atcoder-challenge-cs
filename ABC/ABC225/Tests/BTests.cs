using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5
1 4
2 4
3 4
4 5
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
2 4
1 4
2 3
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
9 10
3 10
4 10
8 10
1 10
2 10
7 10
6 10
5 10
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
