using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"20 4
3 7 8 4";
            const string output = @"777773";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"101 9
9 8 7 6 5 4 3 2 1";
            const string output = @"71111111111111111111111111111111111111111111111111";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"15 3
5 4 6";
            const string output = @"654";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
