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
            const string input = @"7 9
1 2 2
1 3 3
2 5 2
3 4 1
3 5 4
4 7 5
5 6 1
5 7 6
6 7 3
";
            const string output = @"8
8
9
9
8
8
8
";
            Tester.InOutTest(Tasks.M.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 3
1 2 1
2 3 10
3 4 100
";
            const string output = @"111
111
111
111
";
            Tester.InOutTest(Tasks.M.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4 3
1 2 314
1 3 159
1 4 265
";
            const string output = @"265
893
583
265
";
            Tester.InOutTest(Tasks.M.Solve, input, output);
        }
    }
}
