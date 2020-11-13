using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 3 4
100
600
400
900
1000
150
2000
899
799";
            const string output = @"350
1400
301
399";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"1 1 3
1
10000000000
2
9999999999
5000000000";
            const string output = @"10000000000
10000000000
14999999998";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
