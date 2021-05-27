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
            const string input = @"3 5 3
6
1 3 2 5
2 2 1 2
1 3 1 4
2 3 2 5
1 2 3 5
1 2 4 5
";
            const string output = @"2
6
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 4 8
9
1 4 1 4
1 4 1 4
1 4 1 1
1 4 3 3
1 2 1 2
1 2 3 4
3 4 1 2
3 4 3 4
1 4 1 4
";
            const string output = @"1
2
5
6
7
8
9
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
