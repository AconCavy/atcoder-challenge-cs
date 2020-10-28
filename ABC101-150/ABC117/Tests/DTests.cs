using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 7
1 6 3";
            const string output = @"14";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4 9
7 4 0 3";
            const string output = @"46";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"1 0
1000000000000";
            const string output = @"1000000000000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
