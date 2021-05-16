using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
1 1
2 2
3 4
4 8
";
            const string output = @"0
1
4
11
26
36
40
32
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
