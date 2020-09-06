using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2002
2017";
            var output = @"2032";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4500
0";
            var output = @"-4500";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
