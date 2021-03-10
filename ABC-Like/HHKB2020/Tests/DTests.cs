using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3
3 1 2
4 2 2
331895368 154715807 13941326";
            const string output = @"20
32
409369707";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
