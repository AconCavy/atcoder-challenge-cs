using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3
200 1000 1
100 100 300
1000 2000 1000000
";
            const string output = @"1000
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
1 100
1 100
100 1
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5
100 1 1 1 1
1 1 1 1 1
1000000000000000 1000000000000000 1000000000000000 1000000000000000 1000000000000000
";
            const string output = @"4000000000000000
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"18
89 36 77 25 84 49 67 21 78 94 55 50 22 40 44 17 93 11
55 81 89 38 19 65 68 75 66 52 75 93 94 31 73 86 25 79
38 81 44 33 70 20 89 34 13 45 27 88 91 85 36 98 52 93
";
            const string output = @"337
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
