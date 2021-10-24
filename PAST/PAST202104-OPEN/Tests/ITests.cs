using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ITests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5 6
4 5 1 2 6 9
1 3 3 2 7 4
8 3 7 6 2 1
7 8 3 3 7 5
8 4 5 5 5 6
";
            const string output = @"9
16
23
30
36
41
45
48
52
53
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }
    }
}
