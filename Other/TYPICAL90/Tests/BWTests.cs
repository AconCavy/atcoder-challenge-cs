using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BWTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"42
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.BW.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"48
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.BW.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"54
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.BW.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"53
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.BW.Solve, input, output);
        }
    }
}
