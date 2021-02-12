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
            const string input = @"6
1 2 3 2 2 1
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"9
1 2 1 2 1 2 1 2 1
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7
1 2 3 2 1 999999999 1000000000
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
