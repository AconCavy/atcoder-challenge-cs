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
            const string input = @"10 4
100
300
600
700
800
400
500
800
900
900";
            const string output = @"3";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 3
10
40
50
80
90
30
20
40
90
95";
            const string output = @"5";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"8 4
1
2
3
4
5
6
7
8";
            const string output = @"5";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"8 2
100000
90000
50000
30000
10000
4000
200
1";
            const string output = @"0";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
