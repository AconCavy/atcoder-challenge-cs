using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1080 1920
1080 1920";
            var output = @"YES";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1080 1920
1920 1080";
            var output = @"YES";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"334 668
668 1002";
            var output = @"YES";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"100 200
300 150";
            var output = @"NO";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"120 120
240 240";
            var output = @"NO";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
