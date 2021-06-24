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
            const string input = @"3 3
1 3
2 0
3 4
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 100000
22 59
26 60
72 72
47 3
97 16
75 41
82 77
17 97
32 32
28 7
";
            const string output = @"7521307799
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1 100000
1000000000 1000000000
";
            const string output = @"5000050000000000000
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
