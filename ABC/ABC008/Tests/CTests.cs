using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
2
4
8";
            var output = @"2.166666666667";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
5
5
5
5";
            var output = @"2.000000000000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5
2
3
2
6
12";
            var output = @"3.100000000000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -6);
        }
    }
}
