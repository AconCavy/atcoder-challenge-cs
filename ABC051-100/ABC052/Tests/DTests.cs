using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 2 5
1 2 5 7";
            var output = @"11";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7 1 100
40 43 45 105 108 115 124";
            var output = @"84";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"7 1 2
24 35 40 68 72 99 103";
            var output = @"12";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
