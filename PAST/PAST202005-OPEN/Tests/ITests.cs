using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ITests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
19
4 1 1
4 1 2
4 2 1
4 2 2
3
4 1 1
4 1 2
4 2 1
4 2 2
1 1 2
4 1 1
4 1 2
4 2 1
4 2 2
2 2 1
4 1 1
4 1 2
4 2 1
4 2 2
";
            const string output = @"0
1
2
3
0
2
1
3
1
3
0
2
3
1
2
0
";
            Tester.InOutTest(Tasks.i.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
9
2 2 3
3
1 2 1
2 3 2
1 1 3
3
4 1 1
4 2 2
4 2 3
";
            const string output = @"1
6
8
";
            Tester.InOutTest(Tasks.i.Solve, input, output);
        }
    }
}
