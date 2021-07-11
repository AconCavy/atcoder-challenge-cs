using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BRTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
-1 2
1 1
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.BR.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
1 0
0 1
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.BR.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5
2 5
2 5
-3 4
-4 -8
6 -2
";
            const string output = @"35
";
            Tester.InOutTest(Tasks.BR.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"4
1000000000 1000000000
-1000000000 1000000000
-1000000000 -1000000000
1000000000 -1000000000
";
            const string output = @"8000000000
";
            Tester.InOutTest(Tasks.BR.Solve, input, output);
        }
    }
}
