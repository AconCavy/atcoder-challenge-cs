using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AMTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
1 2
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.AM.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
1 2
1 3
1 4
";
            const string output = @"9
";
            Tester.InOutTest(Tasks.AM.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"12
1 2
3 1
4 2
2 5
3 6
3 7
8 4
4 9
10 5
11 7
7 12
";
            const string output = @"211
";
            Tester.InOutTest(Tasks.AM.Solve, input, output);
        }
    }
}
