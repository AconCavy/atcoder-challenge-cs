using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2
1 3
3 5";
            const string output = @"18";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3
11 13
17 47
359 44683";
            const string output = @"998244353";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"1
1 1000000";
            const string output = @"500000500000";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
