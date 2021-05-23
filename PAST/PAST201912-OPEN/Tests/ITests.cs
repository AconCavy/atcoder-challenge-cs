using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ITests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 4
YYY 100
YYN 20
YNY 10
NYY 25
";
            const string output = @"30
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 4
YNNNN 10
NYNNN 10
NNYNN 10
NNNYN 10
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 14
YNNYNNNYYN 774472905
YYNNNNNYYY 75967554
NNNNNNNNNN 829389188
NNNNYYNNNN 157257407
YNNYNNYNNN 233604939
NYYNNNNNYY 40099278
NNNNYNNNNN 599672237
NNNYNNNNYY 511018842
NNNYNNYNYN 883299962
NNNNNNNNYN 883093359
NNNNNYNYNY 54742561
NYNNYYYNNY 386272705
NNNNYYNNNN 565075143
NNYNYNNNYN 123300589
";
            const string output = @"451747367
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }
    }
}
