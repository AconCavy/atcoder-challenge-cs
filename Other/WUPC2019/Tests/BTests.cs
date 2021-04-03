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
            const string input = @"2 3
0 1 2
3 4 5
";
            const string output = @"Yes 1
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 2
1 2
2 1
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 3
6 6 6
6 5 5
6 6 6
6 5 6
6 6 6
";
            const string output = @"Yes 2
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"3 3
1 2 3
4 5 6
7 8 9
";
            const string output = @"Yes 4
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"5 1
6
5
6
5
6";
            const string output = @"Yes 3";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test6()
        {
            const string input = @"1 5
1 5 6 5 6";
            const string output = @"Yes 2";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test7()
        {
            const string input = @"3 3
1 5 1
5 9 5
1 5 9";
            const string output = @"Yes 4";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
