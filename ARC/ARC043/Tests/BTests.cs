using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5
1
2
4
5
10
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10
11
12
13
14
15
16
17
18
19
20
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"20
1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18
19
20
";
            const string output = @"94
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
