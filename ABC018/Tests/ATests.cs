using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"12
18
11";
            var output = @"2
1
3";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10
20
30";
            var output = @"3
2
1";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
