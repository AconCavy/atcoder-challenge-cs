using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 3
2
3
1
";
            const string output = @"1
3
2
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3
1
1
1
";
            const string output = @"1
2
3
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 10
3
1
4
1
5
9
2
6
5
3
";
            const string output = @"3
5
6
2
9
1
4
7
8
10
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
