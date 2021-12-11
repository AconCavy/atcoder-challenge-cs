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
            const string input = @"3 1
100 160 130
120
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 5
1 2 3 4 5
6
5
4
3
2
";
            const string output = @"0
1
2
3
4
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 5
804289384 846930887 681692778 714636916 957747794
424238336
719885387
649760493
596516650
189641422
";
            const string output = @"5
3
5
5
5
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
