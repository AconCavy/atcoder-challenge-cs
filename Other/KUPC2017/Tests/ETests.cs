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
            const string input = @"5 4
20 10 5 8 6
1 2
2 3
3 1
4 5
";
            const string output = @"43
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"7 4
8 10 9 15 6 3 7
1 7
2 3
3 4
5 6
";
            const string output = @"39
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 7
1 9 1 9 1 1 4 5 1 4
1 2
2 3
2 3
3 4
5 6
6 8
7 9
";
            const string output = @"30
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"4 4
20 17 10 1
1 2
1 2
3 3
3 4
";
            const string output = @"48
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
