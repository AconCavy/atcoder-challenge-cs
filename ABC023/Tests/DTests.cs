using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
5 6
12 4
14 7
21 2";
            var output = @"23";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6
100 1
100 1
100 1
100 1
100 1
1 30";
            var output = @"105";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
