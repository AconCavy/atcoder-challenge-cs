using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BXTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"10
1 1 1 1 1 1 1 1 1 1
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.BX.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
1 1 1
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.BX.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3
1 18 1
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.BX.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"4
1 9 1 9
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.BX.Solve, input, output);
        }
    }
}
