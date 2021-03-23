using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"1 2
80 84
";
            const string output = @"84
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 4
37 29 70 41
85 69 76 50
53 10 95 100
";
            const string output = @"250
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"8 2
31000000 41000000
59000000 26000000
53000000 58000000
97000000 93000000
23000000 84000000
62000000 64000000
33000000 83000000
27000000 95000000
";
            const string output = @"581000000
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
