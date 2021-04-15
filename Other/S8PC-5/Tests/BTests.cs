using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"0 2
6 3
2 4
";
            const string output = @"2.061552812808830
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"0 5
8 6
9 1
2 0
1 0
0 1
";
            const string output = @"0.500000000000000
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3 0
5 2 3
-1 0 2
2 -6 4
";
            const string output = @"2.000000000000000
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"1 1
0 0 5
6 -3
";
            const string output = @"1.708203932499369
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }
    }
}
