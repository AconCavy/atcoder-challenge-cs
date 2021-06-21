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
            const string input = @"3 3 10
1 2 3
1 2 4
";
            const string output = @"X
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 3 13
1 2 3 4
4 5 6
";
            const string output = @"Y
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4 4 2
1 1 0 1
1 1 0 1
";
            const string output = @"Same
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
