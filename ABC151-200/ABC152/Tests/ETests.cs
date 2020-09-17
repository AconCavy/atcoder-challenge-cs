using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
2 3 4";
            var output = @"13";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5
12 12 12 12 12";
            var output = @"5";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"3
1000000 999999 999998";
            var output = @"996989508";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
