using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CGTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"42
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.CG.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"7
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.CG.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"192
";
            const string output = @"16
";
            Tester.InOutTest(Tasks.CG.Solve, input, output);
        }
    }
}
