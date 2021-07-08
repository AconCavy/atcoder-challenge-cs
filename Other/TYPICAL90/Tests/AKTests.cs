using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AKTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"100 4
30 40 120
30 40 30
30 40 1500
30 40 40
";
            const string output = @"1660
";
            Tester.InOutTest(Tasks.AK.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"100 4
13 15 31415
12 13 92653
29 33 58979
95 98 32384
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.AK.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5000 5
1000 1000 1000000000
1000 1000 1000000000
1000 1000 1000000000
1000 1000 1000000000
1000 1000 1000000000
";
            const string output = @"5000000000
";
            Tester.InOutTest(Tasks.AK.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"10000 20
4539 6002 485976
1819 5162 457795
1854 2246 487643
1023 4733 393530
1052 6274 289577
1874 2436 167747
1457 4248 452660
2103 4189 174955
3057 5061 319316
4898 4953 394627
1313 2880 154687
1274 1364 259598
3866 5844 233027
1163 5036 386223
1234 4630 155972
2845 4978 442858
3168 5368 171601
3708 4407 394899
3924 4122 428313
2112 4169 441976
";
            const string output = @"2727026
";
            Tester.InOutTest(Tasks.AK.Solve, input, output);
        }
    }
}
