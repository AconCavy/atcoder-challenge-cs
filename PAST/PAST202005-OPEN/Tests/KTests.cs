using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class KTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 4
1 2 1
2 3 2
3 1 3
1 3 2
";
            const string output = @"3
3
1
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 20
3 6 3
6 5 6
10 8 10
5 7 3
1 3 1
4 10 4
5 4 6
10 7 4
7 9 3
9 8 4
8 1 4
3 7 1
2 3 2
9 8 3
8 1 10
8 2 8
9 10 9
2 1 8
4 9 6
1 7 4
";
            const string output = @"7
3
7
7
5
9
7
7
10
7
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }
    }
}
