using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ABTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
1 1 3 2
2 1 4 2
";
            const string output = @"2
1
";
            Tester.InOutTest(Tasks.AB.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
1 1 3 4
3 4 6 5
";
            const string output = @"9
0
";
            Tester.InOutTest(Tasks.AB.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"20
61 98 76 100
70 99 95 100
10 64 96 91
12 37 99 66
63 93 65 95
16 18 18 67
30 47 88 56
33 6 38 8
37 19 40 68
4 56 12 84
3 16 92 78
39 24 67 96
46 1 69 57
40 34 65 65
20 38 51 92
5 32 100 73
7 33 92 55
4 46 97 85
43 18 57 87
15 29 54 74
";
            const string output = @"1806
990
1013
1221
567
839
413
305
228
121
58
40
0
0
0
0
0
0
0
0
";
            Tester.InOutTest(Tasks.AB.Solve, input, output);
        }
    }
}
