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
            const string input = @"6 7
1 1 2
1 2 3
1 3 4
1 1 5
1 5 6
3 1
2 6
";
            const string output = @"NYYNYY
NNYNNN
NNNYNN
NNNNNN
NNNNNY
YNNNYN
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
