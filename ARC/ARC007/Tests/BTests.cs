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
            const string input = @"5 6
2
3
5
0
1
3";
            const string output = @"0
5
2
4
1";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 5
0
1
1
1
2";
            const string output = @"0
1
3";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 0";
            const string output = @"1
2
3
4
5";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"10 7
2
8
5
3
3
8
1";
            const string output = @"8
0
5
4
3
6
7
2
9
10";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"5 7
3
4
3
1
2
2
0";
            const string output = @"3
1
2
4
5";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
