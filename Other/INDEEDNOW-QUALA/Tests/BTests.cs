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
nowindeed
indeedwow
windoneed
indeednow
wondeedni
a
indonow
ddeennoiw
indeednoww
indeow
";
            const string output = @"YES
NO
YES
YES
YES
NO
NO
YES
NO
NO
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
