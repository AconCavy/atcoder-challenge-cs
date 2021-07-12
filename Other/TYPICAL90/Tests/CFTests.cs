using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CFTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
ooxo
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.CF.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
oxoxo
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.CF.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5
ooooo
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.CF.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"7
xxoooxx
";
            const string output = @"16
";
            Tester.InOutTest(Tasks.CF.Solve, input, output);
        }
    }
}
