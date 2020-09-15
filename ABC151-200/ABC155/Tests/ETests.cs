using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"36";
            var output = @"8";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"91";
            var output = @"3";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"314159265358979323846264338327950288419716939937551058209749445923078164062862089986280348253421170";
            var output = @"243";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
