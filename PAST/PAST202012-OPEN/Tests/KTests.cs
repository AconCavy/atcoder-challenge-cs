using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class KTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"#...
....
....
....
";
            const string output = @"5.0000000000
";
            Tester.InOutTest(Tasks.K.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"#...
#...
....
....
";
            const string output = @"7.5000000000
";
            Tester.InOutTest(Tasks.K.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @".#..
#.#.
.#..
....
";
            const string output = @"10.4166666667
";
            Tester.InOutTest(Tasks.K.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"###.
####
####
####
";
            const string output = @"32.5674089515
";
            Tester.InOutTest(Tasks.K.Solve, input, output, RelativeError);
        }
    }
}
