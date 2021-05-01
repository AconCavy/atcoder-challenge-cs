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
            const string input = @"3 3
10 1
10 10
1 10
1 10 1
1 10 1
";
            const string output = @"9
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"7 11
42 77 94 76 40 66 43 28 66 23
27 34 41 31 83 13 64 69 81 82
23 81 0 22 39 51 4 37 84 43
62 37 82 86 26 67 45 78 85 2
79 18 72 62 68 84 69 88 19 48
0 27 21 51 71 13 87 45 39 11
74 57 32 0 97 41 87 96 17 98
69 58 76 32 51 16 38 68 86 82 64
53 47 33 7 51 75 43 14 96 86 70
80 58 12 76 94 50 59 2 1 54 25
14 14 62 28 12 43 15 70 65 44 41
56 50 50 54 53 34 16 3 2 59 88
27 85 50 79 48 86 27 81 78 78 64
";
            const string output = @"498
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4 4
0 0 0
0 0 0
0 0 0
0 0 0
0 0 0 0
0 0 0 0
0 0 0 0
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
