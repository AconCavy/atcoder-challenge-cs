using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5
ababa";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2
xy";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"13
strangeorange";
            const string output = @"5";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
