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
            const string input = @"2 11
1 2 3 4 5 6 7 8 9 10 11
1 2 15 14 13 16 17 18 19 20 21
";
            const string output = @"1 2 3 4 5 6
7 13 14 15 16
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 5
1 2 3 4 5
2 1 3 4 5
1 2 3 4 5
2 1 3 4 5
";
            const string output = @"1 2

3
4 5
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
