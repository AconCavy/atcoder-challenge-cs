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
            const string input = @"3 7 20
1 2 4
";
            const string output = @"3 6 11
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3 100
1 1 1
";
            const string output = @"34 33 33
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"6 10006 10
10000 3 2 1 0 0
";
            const string output = @"10 0 0 0 0 0
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"7 78314 1000
53515 10620 7271 3817 1910 956 225
";
            const string output = @"683 136 93 49 24 12 3
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }
    }
}
