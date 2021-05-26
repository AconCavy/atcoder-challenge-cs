using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class HTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 5
1 4
2 2 20
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 5
1 2 3 4
2 20 100
";
            const string output = @"164
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 19
1 3 4 5 7 8 10 13 15 17
2 1000 10
";
            const string output = @"138
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }
    }
}
