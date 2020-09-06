using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"7
100 130 130 130 115 115 150";
            var output = @"1685";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6
200 180 160 140 120 100";
            var output = @"1000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"2
157 193";
            var output = @"1216";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"6
100 120 130 200 100 100";
            var output = @"2000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
