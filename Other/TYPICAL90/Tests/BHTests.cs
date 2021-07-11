using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BHTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6
1 2 3 3 2 1
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.BH.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
1 2 3 4
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.BH.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5
3 3 3 3 3
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.BH.Solve, input, output);
        }
    }
}
