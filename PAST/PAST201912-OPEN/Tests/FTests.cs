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
            const string input = @"FisHDoGCaTAAAaAAbCAC
";
            const string output = @"AAAaAAbCACCaTDoGFisH
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"AAAAAjhfgaBCsahdfakGZsZGdEAA
";
            const string output = @"AAAAAAAjhfgaBCsahdfakGGdEZsZ
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
