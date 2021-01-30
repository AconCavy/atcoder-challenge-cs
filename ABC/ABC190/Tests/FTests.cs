using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
0 1 2 3
";
            const string output = @"0
3
4
3
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10
0 3 1 5 4 2 9 6 8 7
";
            const string output = @"9
18
21
28
27
28
33
24
21
14
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
