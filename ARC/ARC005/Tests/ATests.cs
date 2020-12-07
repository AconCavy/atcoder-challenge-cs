using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5
Takahashikun is not an eel.";
            const string output = @"1";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
TAKAHASHIKUN loves TAKAHASHIKUN and takahashikun.";
            const string output = @"3";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"6
He is not takahasikun but Takahashikun.";
            const string output = @"1";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"1
takahashikunTAKAHASHIKUNtakahashikun.";
            const string output = @"0";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"18
You should give Kabayaki to Takahashikun on July twenty seventh if you suspect that he is an eel.";
            const string output = @"1";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
