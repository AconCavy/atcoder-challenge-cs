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
            const string input = @"5 3
(())(
2 1 4
2 1 2
2 4 5
";
            const string output = @"Yes
No
No
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 3
(())(
2 1 4
1 1 4
2 1 4
";
            const string output = @"Yes
No
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"8 8
(()(()))
2 2 7
2 2 8
1 2 5
2 3 4
1 3 4
1 3 5
1 1 4
1 6 8
";
            const string output = @"Yes
No
No
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
