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
            const string input = @"3
7 3
9 2
2 5
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
999999999 1000000000
1 999999999
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"2
999999999 1
1000000000 1
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"3
100 17
171 10
91 19
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }
    }
}
