using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BZTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5 5
1 2
1 3
3 2
5 2
4 2
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.BZ.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 1
1 2
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.BZ.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7 18
7 2
1 6
5 2
1 3
7 6
5 3
5 6
5 4
1 7
2 6
3 4
5 1
4 7
4 6
5 7
3 2
4 2
1 4
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.BZ.Solve, input, output);
        }
    }
}
