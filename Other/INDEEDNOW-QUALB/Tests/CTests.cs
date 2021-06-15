using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
1 3
1 4
2 3
";
            const string output = @"1 3 2 4
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6
1 2
2 3
2 6
6 4
1 5
";
            const string output = @"1 2 3 5 6 4
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7
1 5
5 2
5 3
5 7
5 6
6 4
";
            const string output = @"1 5 2 3 6 4 7
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
