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
            const string input = @"3 5
3 3
4 4
2 5
";
            const string output = @"8
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 6
3 3
4 4
2 5
";
            const string output = @"9
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7 14
10 5
7 4
11 4
9 8
3 6
6 2
8 9
";
            const string output = @"32
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
