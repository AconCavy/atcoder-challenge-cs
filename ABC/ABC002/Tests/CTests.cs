using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1 0 3 0 2 5";
            var output = @"5.0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"-1 -2 3 4 5 6";
            var output = @"2.0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -2);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"298 520 903 520 4 663";
            var output = @"43257.5";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -2);
        }
    }
}
