using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class HTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
5 3 3 5
6
1 2 1
2 2
2 2
3 100
3 1
1 1 3
";
            const string output = @"9
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10
241 310 105 738 405 490 158 92 68 20
20
2 252
1 4 36
2 69
1 5 406
3 252
1 3 8
1 10 10
3 11
1 4 703
3 1
2 350
3 10
2 62
2 3
2 274
1 2 1
3 126
1 4 702
3 6
2 174
";
            const string output = @"390
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"2
3 4
3
1 2 9
2 4
3 4
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }
    }
}
