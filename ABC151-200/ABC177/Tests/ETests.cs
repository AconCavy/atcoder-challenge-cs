using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
3 4 5";
            var output = @"pairwise coprime";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
6 10 15";
            var output = @"setwise coprime";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"3
6 10 16";
            var output = @"not coprime";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"5
1 3 3 2 2";
            var output = @"setwise coprime";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
