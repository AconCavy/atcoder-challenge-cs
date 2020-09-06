using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1 1 8 2 2 4
1
4 5";
            var output = @"NO";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1 1 8 2 2 6
1
4 5";
            var output = @"YES";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1 1 8 2 2 5
1
4 5";
            var output = @"YES";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"7 7 1 1 3 4
3
8 1
1 7
9 9";
            var output = @"YES";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
