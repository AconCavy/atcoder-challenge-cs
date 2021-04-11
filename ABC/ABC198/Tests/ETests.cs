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
            const string input = @"6
2 7 1 8 2 8
1 2
3 6
3 2
4 3
2 5
";
            const string output = @"1
2
3
4
6
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10
3 1 4 1 5 9 2 6 5 3
1 2
2 3
3 4
4 5
5 6
6 7
7 8
8 9
9 10
";
            const string output = @"1
2
3
5
6
7
8
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
