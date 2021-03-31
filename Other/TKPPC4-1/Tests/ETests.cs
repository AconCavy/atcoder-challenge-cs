using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 5 3 1
5 2 6 5
6 3 4 8 2";
            const string output = @"Yes
3";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 5 2 1
5 2 6 5
6 3 4 8 2";
            const string output = @"No
3";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1 15 14 86
92
47 98 3 71 37 46 87 39 75 65 100 44 91 85 52";
            const string output = @"Yes
1";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"20 1 1 91
40 66 82 48 3 46 25 51 65 12 96 66 40 97 100 13 62 98 6 1
68";
            const string output = @"No
8";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
