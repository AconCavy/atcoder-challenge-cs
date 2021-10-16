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
            const string input = @"5 5 2
1 2 3 4 5
1 2
1 2
1 3
4 2
4 3
3 5
";
            const string output = @"0
0
1
1
2
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 6 2
6 5 9 15 3
4 2
1 5
2 5
2 4
1 3
4 3
2 1
";
            const string output = @"1
0
2
0
-1
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 4 2
3 10 5 8 2
3 5
3 2
3 1
4 5
2 1
";
            const string output = @"-1
1
0
1
0
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }
    }
}
