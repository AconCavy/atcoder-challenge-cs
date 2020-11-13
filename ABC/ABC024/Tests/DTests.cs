using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"15
35
21";
            var output = @"4 2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"126
252
210";
            var output = @"5 4";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"144949225
545897619
393065978";
            var output = @"314159 365358";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
