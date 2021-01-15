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
            const string input = @"3 3 2
1 2
2 3
1 3
";
            const string output = @"1
2
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 6 5
1 5
3 5
3 2
4 1
1 2
4 3
";
            const string output = @"1
2
3
5
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 5 5
1 4
4 3
3 2
2 5
5 1
";
            const string output = @"1
2
5
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
