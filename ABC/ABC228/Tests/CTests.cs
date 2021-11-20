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
            const string input = @"3 1
178 205 132
112 220 96
36 64 20
";
            const string output = @"Yes
Yes
No
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 1
300 300 300
200 200 200
";
            const string output = @"Yes
Yes
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4 2
127 235 78
192 134 298
28 56 42
96 120 250
";
            const string output = @"Yes
Yes
No
Yes
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
