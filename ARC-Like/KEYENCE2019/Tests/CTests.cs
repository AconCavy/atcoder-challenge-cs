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
            const string input = @"3
2 3 5
3 4 1
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
2 3 3
2 2 1
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3
17 7 1
25 6 14
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"12
757232153 372327760 440075441 195848680 354974235 458054863 463477172 740174259 615762794 632963102 529866931 64991604
74164189 98239366 465611891 362739947 147060907 118867039 63189252 78303147 501410831 110823640 122948912 572905212
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
