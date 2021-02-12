using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class MTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;


        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 4
1 2 3
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.M.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1 10
9
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.M.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"2 0
0 0
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.M.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"4 100000
100000 100000 100000 100000
";
            const string output = @"665683269
";
            Tester.InOutTest(Tasks.M.Solve, input, output);
        }
    }
}
