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
            const string input = @"1
tokyoinstituteoftechnology
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8
okyoech
tokyotech
titech
tokyotokyotechtech
tokyotecg
tttoookkkyyyooottteeeccchhh
tokyokogyodaigaku
tokyouniversityofagricultureandtechnology
";
            const string output = @"Yes
Yes
No
Yes
No
No
No
Yes
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
