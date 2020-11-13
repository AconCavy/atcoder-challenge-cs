using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
7 1
2
5
10";
            var output = @"8";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2
8 20
1
10";
            var output = @"29";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5
30 44
26
18
81
18
6";
            var output = @"56";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
