using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AFTests
    {
        const int TimeLimit = 5000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3
1 10 100
10 1 100
100 10 1
1
1 2
";
            const string output = @"111
";
            Tester.InOutTest(Tasks.AF.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
1 2 3 4
5 6 7 8
9 10 11 12
13 14 15 16
3
1 2
1 3
2 3
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.AF.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3
1 10 100
10 1 100
100 10 1
0
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.AF.Solve, input, output);
        }
    }
}
