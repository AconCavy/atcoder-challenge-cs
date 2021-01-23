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
            const string input = @"1
1 2
4
1
3 3
2
4 2
5
0 1
1 1
2 1
3 1
4 1
";
            const string output = @"1 2
2 -1
4 -1
1 4
1 0
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
1000000000 0
0 1000000000
4
3 -1000000000
4 -1000000000
3 1000000000
4 1000000000
2
4 1
4 2
";
            const string output = @"5000000000 4000000000
4000000000 5000000000
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
