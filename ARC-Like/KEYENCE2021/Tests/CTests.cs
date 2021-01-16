using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 3000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 2 3
1 1 X
2 1 R
2 2 R
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3 5
2 3 D
1 3 D
2 1 D
1 2 X
3 1 R
";
            const string output = @"150
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5000 5000 10
585 1323 R
2633 3788 X
1222 4989 D
1456 4841 X
2115 3191 R
2120 4450 X
4325 2864 X
222 3205 D
2134 2388 X
2262 3565 R
";
            const string output = @"139923295
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
