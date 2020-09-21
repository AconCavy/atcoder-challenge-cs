using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"6 5
4 7 10 6 5";
            var output = @"8";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10 5
4 7 10 6 5";
            var output = @"9";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"100 0
";
            var output = @"100";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
