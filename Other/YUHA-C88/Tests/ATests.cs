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
            const string input = @"8
MIDDLE OF CHAOS
BEGINNING OF LEGEND
END OF PEACE
BEGINNING OF FINALE
END OF BEGINNING
MIDDLE OF WAR
BEGINNING OF RUIN
BEGINNING OF DESTRUCTION
";
            const string output = @"ALEFGARD";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
BEGINNING OF ATCODER
MIDDLE OF ATCODER
END OF ATCODER
";
            const string output = @"AOR";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
