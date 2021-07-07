using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ZTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
1 2
2 3
2 4
";
            const string output = @"1 3
";
            Tester.InOutTest(Tasks.Z.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6
1 3
2 4
3 5
2 5
3 6
";
            const string output = @"1 4 5
";
            Tester.InOutTest(Tasks.Z.Solve, input, output);
        }
    }
}
