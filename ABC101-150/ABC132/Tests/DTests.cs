using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5 3";
            const string output = @"3
6
1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2000 3";
            const string output = @"1998
3990006
327341989";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
