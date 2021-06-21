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
            const string input = @"2 3 3
1 2
2 1
2 2
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 5 10
2 2
2 5
1 3
2 4
2 3
1 5
2 1
1 4
1 2
1 1
";
            const string output = @"28
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"100000 100000 0
";
            const string output = @"500000000000000
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"2 2 3
1 2
2 1
2 2
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
