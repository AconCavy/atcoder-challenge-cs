using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"10";
            const string output = @"5";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"1111111111111111111";
            const string output = @"162261460";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
