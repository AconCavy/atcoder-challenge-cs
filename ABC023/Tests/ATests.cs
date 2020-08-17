using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"23";
            var output = @"5";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"70";
            var output = @"7";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"99";
            var output = @"18";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
