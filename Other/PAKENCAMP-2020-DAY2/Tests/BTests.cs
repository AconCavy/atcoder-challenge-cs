using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"1 1
S
";
            const string output = @"1";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1 2
ES
";
            const string output = @"1";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"2 3
EEE
SSS
";
            const string output = @"2";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"10 10
SEESESESES
EEESESEEES
EESESEESES
EESSSSESES
SEESSEEEEE
EESESEEESS
EEEESSEEEE
SESESESSES
SEESSEESSE
EESSSSSESS
";
            const string output = @"3";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
