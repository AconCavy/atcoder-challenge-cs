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
            const string input = @"10 1
100 200 300 400 500 600 700 800 900 1000
1000 3 1 2 3
";
            const string output = @"6100
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"12 10
1000 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000
1000 4 1 2 4 7
1000 4 1 9 11 12
1000 4 3 5 8 9
1000 4 6 10 11 12
1000 4 2 4 7 10
1000 4 1 8 9 10
1000 3 1 9 12
1000 4 3 8 11 12
1000 4 1 2 3 4
1000 4 7 8 9 10
";
            const string output = @"19000
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"13 8
328 781 104 102 132 108 100 102 104 108 168 102 100
184 4 10 11 3 4
190 4 9 6 2 5
282 6 9 1 3 12 10 8
205 8 13 10 1 12 7 2 8 11
122 8 13 5 4 3 8 9 12 10
112 7 11 6 12 8 2 13 5
102 4 4 13 6 12
109 6 7 2 13 1 8 6
";
            const string output = @"3239
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
