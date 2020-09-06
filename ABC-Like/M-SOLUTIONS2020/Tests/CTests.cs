using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 3
96 98 95 100 20";
            var output = @"Yes
No";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 2
1001 869120 1001";
            var output = @"No";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"15 7
3 1 4 1 5 9 2 6 5 3 5 8 9 7 9";
            var output = @"Yes
Yes
No
Yes
Yes
No
Yes
Yes";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
