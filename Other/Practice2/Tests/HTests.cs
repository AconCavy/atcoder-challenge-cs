using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class HTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 2
1 4
2 5
0 6";
            var output = @"Yes
4
2
0";
            Tester.InOutTest(() => Tasks.H.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 3
1 4
2 5
0 6";
            var output = @"No";
            Tester.InOutTest(() => Tasks.H.Solve(), input, output);
        }
    }
}
