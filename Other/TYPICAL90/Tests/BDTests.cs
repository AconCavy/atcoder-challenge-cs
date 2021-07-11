using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BDTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 34
3 14
15 9
26 5
";
            const string output = @"BAB
";
            Tester.InOutTest(Tasks.BD.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 77
1 16
3 91
43 9
4 26
23 11
";
            const string output = @"BAAAB
";
            Tester.InOutTest(Tasks.BD.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 59
8 13
55 5
58 8
23 14
4 61
";
            const string output = @"Impossible
";
            Tester.InOutTest(Tasks.BD.Solve, input, output);
        }
    }
}
