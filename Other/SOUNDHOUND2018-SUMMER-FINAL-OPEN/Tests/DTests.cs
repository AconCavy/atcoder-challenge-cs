using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 6
1 1 2
1 2 3
3 1 2
3 1 3
2 1 0
3 1 3
";
            const string output = @"Yes
No
Yes
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 6
2 3 0
3 1 3
1 3 1
2 3 0
1 1 2
3 2 1
";
            const string output = @"No
Yes
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"8 20
1 3 6
2 6 0
2 2 0
2 7 0
1 7 3
3 2 6
1 4 2
3 3 7
1 2 6
2 4 0
2 2 0
3 3 1
2 8 0
2 8 0
1 8 2
2 7 0
3 5 4
1 4 2
3 5 7
3 2 3
";
            const string output = @"No
Yes
No
No
No
Yes
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
