using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class JTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 5
5 3 2 4 8
";
            const string output = @"1
2
-1
2
1
";
            Tester.InOutTest(Tasks.J.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 10
13 16 6 15 10 18 13 17 11 3
";
            const string output = @"1
1
2
2
3
1
3
2
4
5
";
            Tester.InOutTest(Tasks.J.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 30
35 23 43 33 38 25 22 39 22 6 41 1 15 41 3 20 50 17 25 14 1 22 5 10 34 38 1 12 15 1
";
            const string output = @"1
2
1
2
2
3
4
2
5
6
2
7
6
3
7
6
1
7
4
8
9
6
9
9
4
4
10
9
8
-1
";
            Tester.InOutTest(Tasks.J.Solve, input, output);
        }
    }
}
