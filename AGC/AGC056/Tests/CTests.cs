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
            const string input = @"4 2
1 2
3 4
";
            const string output = @"0101
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6 2
1 4
3 6
";
            const string output = @"001100
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"20 10
6 17
2 3
14 19
5 14
10 15
7 20
10 19
3 20
6 9
7 12
";
            const string output = @"00100100101101001011
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
