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
            const string input = @"3
aba
";
            const string output = @"ba
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"7
sptaast
";
            const string output = @"past
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"30
ryfoxchyvfmsewlwpoyvhdjkbvdjsa
";
            const string output = @"rxcfmelwpoyhkbvdjsa
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
