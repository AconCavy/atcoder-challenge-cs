using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"1";
            const string output = @"Hello World";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2
3
5";
            const string output = @"8";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
