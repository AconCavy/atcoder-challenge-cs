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
            const string input = @"1
2 2
1 2
2 1
";
            const string output = @"0";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
4 3
2 1
3 2
4 1
";
            const string output = @"2";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1
6 6
1 3
3 6
1 6
6 2
2 4
2 5
";
            const string output = @"3";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"2
6 13
2 5
2 4
2 6
4 6
3 2
3 5
4 2
1 4
1 3
5 1
6 4
6 1
5 2
5 10
3 5
5 3
5 4
4 1
2 1
5 4
5 1
3 5
1 5
5 1
";
            const string output = @"1
4";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
