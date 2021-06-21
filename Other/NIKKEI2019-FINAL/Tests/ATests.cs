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
            const string input = @"4
4 1 3 3
";
            const string output = @"4
6
8
11
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
10 20 30 40 50
";
            const string output = @"50
90
120
140
150
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
61049214 115057849 356385814 932678664 505961980 877482753 476308661 571830644 210047210 873430114
";
            const string output = @"932678664
1438640644
2316123397
2792432058
3364262702
3720648516
4447740026
4804125840
4919183689
4980232903
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
