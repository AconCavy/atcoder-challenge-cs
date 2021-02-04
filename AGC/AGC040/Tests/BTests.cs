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
            const string input = @"4
4 7
1 4
5 8
2 5
";
            const string output = @"6
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
1 20
2 19
3 18
4 17
";
            const string output = @"34
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
457835016 996058008
456475528 529149798
455108441 512701454
455817105 523506955
457368248 814532746
455073228 459494089
456651538 774276744
457667152 974637457
457293701 800549465
456580262 636471526
";
            const string output = @"540049931
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
