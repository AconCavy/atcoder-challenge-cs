using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class HTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 4
1S23
4567
89G1
";
            const string output = @"17
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1 11
S134258976G
";
            const string output = @"20
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3 3
S12
4G7
593
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }
    }
}
