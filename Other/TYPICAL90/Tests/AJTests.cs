using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AJTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 3
-1 2
1 1
-2 -3
1
2
3
";
            const string output = @"6
7
7
";
            Tester.InOutTest(Tasks.AJ.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 3
-2 -2
-1 -1
0 0
1 1
2 2
5
3
1
";
            const string output = @"8
4
8
";
            Tester.InOutTest(Tasks.AJ.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"2 1
-1000000000 -1000000000
1000000000 1000000000
1
";
            const string output = @"4000000000
";
            Tester.InOutTest(Tasks.AJ.Solve, input, output);
        }
    }
}
