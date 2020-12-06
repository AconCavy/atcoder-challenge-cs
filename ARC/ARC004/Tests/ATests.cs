using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-3;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3
1 1
2 4
4 3";
            const string output = @"3.605551";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10
1 8
4 0
3 7
2 4
5 9
9 1
6 2
0 2
8 6
7 8";
            const string output = @"10.630146";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4
0 0
0 100
100 0
100 100";
            const string output = @"141.421356";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"5
3 0
1 0
0 0
4 0
2 0";
            const string output = @"4.000000";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"4
2 2
0 0
1 1
3 3";
            const string output = @"4.242641";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }
    }
}
