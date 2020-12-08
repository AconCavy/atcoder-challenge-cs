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
            const string input = @"1 2 3 4 5 6
7
1 2 3 4 5 6";
            const string output = @"1";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"0 1 3 5 7 9
4
0 2 4 6 8 9";
            const string output = @"0";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"0 2 6 7 8 9
4
0 5 6 7 8 9";
            const string output = @"3";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"1 3 5 6 7 8
9
3 5 6 7 8 9";
            const string output = @"2";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"0 1 3 4 5 7
8
2 3 5 7 8 9";
            const string output = @"5";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
