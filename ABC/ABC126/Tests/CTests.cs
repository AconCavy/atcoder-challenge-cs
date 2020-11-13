using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 10";
            const string output = @"0.145833333333";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -9);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"100000 5";
            const string output = @"0.999973749998";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -9);
        }
    }
}
