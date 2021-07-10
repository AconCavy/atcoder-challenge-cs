using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3
abcd
bcda
ada
";
            const string output = @"Aoki
Takahashi
Draw
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
ABC
";
            const string output = @"Draw
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5
eaaaabaa
eaaaacaa
daaaaaaa
eaaaadaa
daaaafaa
";
            const string output = @"Takahashi
Takahashi
Takahashi
Aoki
Takahashi
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
