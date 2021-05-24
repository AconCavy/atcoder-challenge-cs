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
1 3
2 2
2 4
";
            const string output = @"3
7
9
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
5 3
4 1
3 4
2 1
1 5
";
            const string output = @"5
6
10
11
14
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"6
1 8
1 6
2 9
3 1
3 2
4 1
";
            const string output = @"8
17
23
25
26
27
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
