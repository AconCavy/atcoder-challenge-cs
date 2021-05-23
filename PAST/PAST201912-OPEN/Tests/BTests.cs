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
            const string input = @"10
9
10
3
100
100
90
80
10
30
10
";
            const string output = @"up 1
down 7
up 97
stay
down 10
down 10
down 70
up 20
down 20
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
