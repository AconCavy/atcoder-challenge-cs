using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
2 6 1 4 5";
            var output = @"YES";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6
4 1 3 1 6 2";
            var output = @"NO";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"2
10000000 10000000";
            var output = @"NO";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
