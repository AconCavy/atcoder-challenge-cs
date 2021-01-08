using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5 2 4
2
4
6
8
10
";
            const string output = @"0.5 -1
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"13 29 31
3
1
4
1
5
9
2
6
5
3
5
8
9
";
            const string output = @"3.875 10.8173076
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 1 2
34
34
34
34
34
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }
    }
}
