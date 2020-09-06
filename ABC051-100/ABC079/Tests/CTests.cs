using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1222";
            var output = @"1+2+2+2=7";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"0290";
            var output = @"0-2+9-0=7";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"3242";
            var output = @"3+2+4-2=7";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
