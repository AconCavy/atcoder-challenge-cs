using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
0 0 300 10
0 100 10 100
0 200 10 200
0 300 10 300";
            const string output = @"3";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
0 0 100 10
0 90 10 10
0 100 30 100
-20 100 10 10";
            const string output = @"3";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1
0 0 3 3";
            const string output = @"0";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"4
58 -49 38 109
45 -29 200 56
-32 123 103 98
49 -234 289 43";
            const string output = @"4.874179";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"8
100 100 30 50
100 50 93 123
100 0 89 111
50 100 13 18
50 0 155 86
0 100 30 58
0 50 58 49
0 0 98 153";
            const string output = @"7.666667";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }
    }
}
