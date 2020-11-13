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
1 1
2 4
3 2";
            var output = @"4";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2
1 1
1 1";
            var output = @"0";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
