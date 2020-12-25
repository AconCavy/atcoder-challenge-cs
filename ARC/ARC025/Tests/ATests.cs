using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 2 0 5 6 2 5
6 1 4 3 6 4 6
";
            const string output = @"33
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1 2 3 4 5 6 7
2 3 4 5 6 7 8
";
            const string output = @"35
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"0 0 0 0 0 0 0
0 0 0 0 0 0 0
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"8 3 0 2 5 25 252
252 252 2 5 2 5 2
";
            const string output = @"793
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
