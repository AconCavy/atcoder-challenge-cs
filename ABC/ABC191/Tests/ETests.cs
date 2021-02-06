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
            const string input = @"4 4
1 2 5
2 3 10
3 1 15
4 3 20
";
            const string output = @"30
30
30
-1
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 6
1 2 5
1 3 10
2 4 5
3 4 10
4 1 10
1 1 10
";
            const string output = @"10
20
30
20
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4 7
1 2 10
2 3 30
1 4 15
3 4 25
3 4 20
4 3 20
4 3 30
";
            const string output = @"-1
-1
40
40
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
