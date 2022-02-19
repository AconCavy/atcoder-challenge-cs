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
            const string input = @"5 2
1 2 3 4 5
1 4
2 1
2 5
3 2
1 2
2 1
";
            const string output = @"4
5
";
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6 2
10 10 10 9 8 8
1 4
2 1
2 5
3 2
6 4
1 4
2 2
";
            const string output = @"9
10
";
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4 4
1 10 100 1000
1 2
2 3
3 4
1 4
2 3
3 2
4 1
";
            const string output = @"1
10
100
1000
";
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
