using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 2 4
1 1 10
2 1 20
2 2 5
1 1 30
";
            const string output = @"20
50
55
85
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3 5
1 3 10
2 1 7
1 3 5
2 2 10
2 1 1
";
            const string output = @"30
44
31
56
42
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"200000 200000 4
2 112219 100000000
1 73821 100000000
2 26402 100000000
1 73821 100000000
";
            const string output = @"20000000000000
39999900000000
59999800000000
59999800000000
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
