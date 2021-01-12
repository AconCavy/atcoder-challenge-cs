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
            const string input = @"MinnnahaNakayoshi
0 6 8 17
";
            const string output = @"""Minnna""ha""Nakayoshi""
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"Niwawo_Kakemeguru_Chokudai
11 17 18 26
";
            const string output = @"Niwawo_Kake""meguru""_""Chokudai""
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"___
0 1 2 3
";
            const string output = @"""_""_""_""
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
