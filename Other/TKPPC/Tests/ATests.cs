using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
10 3
5 11
";
            const string output = @"13
16
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
5 16
59 14
3 17
";
            const string output = @"21
73
20
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
67 41
0 34
24 69
58 78
64 62
45 5
27 81
91 61
42 95
36 27
";
            const string output = @"108
34
93
136
126
50
108
152
137
63
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
