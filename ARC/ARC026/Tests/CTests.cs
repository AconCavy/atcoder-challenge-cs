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
            const string input = @"5 5
0 1 1
1 2 1
2 4 3
3 5 1
2 3 2
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8 10
0 2 1
2 3 1
0 4 1
0 2 1
3 7 1
0 10 1080
8 10 1
9 10 1
";
            const string output = @"1080
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 10
0 1 1
1 2 1
2 3 1
3 4 1
4 5 1
0 5 4
5 7 2
6 8 3
8 10 1
2 9 3
";
            const string output = @"6
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"5 5
0 1 100000
1 2 100000
2 3 100000
3 4 100000
4 5 100000
";
            const string output = @"500000
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
