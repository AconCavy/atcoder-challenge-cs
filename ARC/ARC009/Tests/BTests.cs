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
            const string input = @"0 8 1 3 5 4 9 7 6 2
10
1
2
3
4
5
6
7
8
9
10";
            const string output = @"8
1
3
5
4
9
7
6
2
10";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"0 9 8 7 6 5 4 3 2 1
3
13467932
98738462
74392";
            const string output = @"74392
98738462
13467932";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"0 1 2 3 4 5 6 7 8 9
4
643
1234
43
909";
            const string output = @"43
643
909
1234";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"0 7 4 3 9 5 6 2 1 8
2
333
333";
            const string output = @"333
333";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"0 2 4 6 8 1 3 5 7 9
1
10";
            const string output = @"10";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
