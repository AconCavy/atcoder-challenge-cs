using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AHTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5 1
1 2 3 4 5
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.AH.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 4
1 1 2 4 2
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.AH.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 2
1 2 3 4 4 3 2 1 2 3
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.AH.Solve, input, output);
        }
    }
}
