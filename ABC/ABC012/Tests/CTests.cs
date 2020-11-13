using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2013";
            var output = @"2 x 6
3 x 4
4 x 3
6 x 2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2024";
            var output = @"1 x 1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
