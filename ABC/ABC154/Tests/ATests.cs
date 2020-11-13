using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"red blue
3 4
red";
            var output = @"2 4";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"red blue
5 5
blue";
            var output = @"5 4";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
