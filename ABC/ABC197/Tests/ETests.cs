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
            const string input = @"5
2 2
3 1
1 3
4 2
5 3
";
            const string output = @"12
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"9
5 5
-4 4
4 3
6 3
-5 5
-3 2
2 2
3 3
1 4
";
            const string output = @"38
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
