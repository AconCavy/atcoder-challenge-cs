using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class KTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3
50 40
30 29
60 55
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
652 175
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
859 346
669 705
344 425
693 747
24 808
462 344
930 67
878 35
906 253
531 832
";
            const string output = @"1696
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }
    }
}
