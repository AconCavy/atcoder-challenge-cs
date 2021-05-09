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
            const string input = @"5 3 100 60
86
23
49
39
";
            const string output = @"45
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 3 100 60
92
100
95
99
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 3 100 60
18
42
29
31
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"13 10 1000000000 645245296
492014535
611893452
729291030
392019922
293849201
474839528
702912832
341845861
102495671
908590572
812912432
129855439
";
            const string output = @"986132796
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
