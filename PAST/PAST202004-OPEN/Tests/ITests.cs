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
2 4 3 1
";
            const string output = @"1
2
2
1
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
2 1
";
            const string output = @"1
1
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3
4 7 5 1 6 3 2 8
";
            const string output = @"1
3
2
1
2
1
1
3
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }
    }
}
