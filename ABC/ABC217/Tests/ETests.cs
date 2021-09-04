using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"8
1 4
1 3
1 2
1 1
3
2
1 0
2
";
            const string output = @"1
2
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"9
1 5
1 5
1 3
2
3
2
1 6
3
2
";
            const string output = @"5
3
5
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
