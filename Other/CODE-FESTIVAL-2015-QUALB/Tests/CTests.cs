using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 2
2 2 3
3 1
";
            const string output = @"YES
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 2
2 2 3
3 3
";
            const string output = @"NO
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3 4
10 10 10
1 1 1 1
";
            const string output = @"NO
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"10 10
10 9 8 7 6 5 4 3 2 1
10 9 8 7 6 5 4 3 2 1
";
            const string output = @"YES
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
