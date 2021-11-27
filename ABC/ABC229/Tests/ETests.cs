using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6 7
1 2
1 4
1 5
2 4
2 3
3 5
3 6
";
            const string output = @"1
2
3
2
1
0
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8 7
7 8
3 4
5 6
5 7
5 8
6 7
6 8
";
            const string output = @"3
2
2
1
1
1
1
0
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
