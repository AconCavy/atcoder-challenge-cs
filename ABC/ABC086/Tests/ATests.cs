using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 4";
            var output = @"Even";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1 21";
            var output = @"Odd";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
