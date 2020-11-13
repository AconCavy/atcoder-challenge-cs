using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 1000
120
100
140";
            var output = @"9";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 360
90
90
90
90";
            var output = @"4";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5 3000
150
130
150
130
110";
            var output = @"26";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
