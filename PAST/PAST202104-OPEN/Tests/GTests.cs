using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class GTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 3 4
1 2 7
1 3 3
2 3 5
2 4 6 8
";
            const string output = @"1
2
3
3
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 7 5
1 2 6
2 3 4
1 3 3
1 4 1
3 4 6
3 5 5
1 5 9
1 5 4 3 5
";
            const string output = @"2
3
4
4
5
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4 1 3
1 4 100
50 100 1000000000
";
            const string output = @"1
2
2
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }
    }
}
