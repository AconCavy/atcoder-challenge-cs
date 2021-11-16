using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class GTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6
";
            const string output = @"2
-3 9
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"9193
";
            const string output = @"9
1 3 9 27 -81 -243 729 2187 6561
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10120190919012
";
            const string output = @"16
9 -27 -2187 -6561 -177147 -531441 -1594323 -4782969 387420489 1162261467 3486784401 10460353203 31381059609 -94143178827 2541865828329 7625597484987
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }
    }
}
