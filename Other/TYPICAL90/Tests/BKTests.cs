using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BKTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 6
1 1 1 1 1 2
1 2 2 2 2 2
1 2 2 3 2 3
1 2 3 2 2 3
";
            const string output = @"6
";
            Tester.InOutTest(Tasks.BK.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3
1 2 3
4 5 6
7 8 9
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.BK.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 3
7 7 7
7 7 7
7 7 7
7 7 7
7 7 7
";
            const string output = @"15
";
            Tester.InOutTest(Tasks.BK.Solve, input, output);
        }
    }
}
