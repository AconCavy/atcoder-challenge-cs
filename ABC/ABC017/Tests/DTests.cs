using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 2
1
2
1
2
2";
            var output = @"5";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6 6
1
2
3
4
5
6";
            var output = @"32";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
