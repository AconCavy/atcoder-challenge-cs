using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class NTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
10 20 30 40
";
            const string output = @"190
";
            Tester.InOutTest(Tasks.N.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
10 10 10 10 10
";
            const string output = @"120
";
            Tester.InOutTest(Tasks.N.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3
1000000000 1000000000 1000000000
";
            const string output = @"5000000000
";
            Tester.InOutTest(Tasks.N.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"6
7 6 8 6 1 1
";
            const string output = @"68
";
            Tester.InOutTest(Tasks.N.Solve, input, output);
        }
    }
}
