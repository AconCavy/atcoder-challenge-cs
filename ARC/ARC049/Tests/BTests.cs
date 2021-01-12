using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-4;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
0 0 1
10 10 1
";
            const string output = @"5.000000000000000
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
0 0 1
10 10 2
";
            const string output = @"6.666666666666667
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
-27 -67 10
59 13 10
14 -15 9
-29 -84 7
-75 -2 2
-12 -74 5
77 31 9
40 64 8
-81 32 1
81 26 5
";
            const string output = @"582.222222222222222
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"8
-81739 73917 446
42230 30484 911
79354 -50126 200
33440 -47087 651
-73 84114 905
79222 -53608 713
65194 -46284 685
81145 40933 47
";
            const string output = @"54924095.383189122374461
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }
    }
}
