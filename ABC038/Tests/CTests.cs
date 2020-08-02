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
1 2 3 2 1";
            var output = @"8";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
1 2 3 4";
            var output = @"10";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6
3 3 4 1 2 2";
            var output = @"8";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"6
1 5 2 3 4 2";
            var output = @"10";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
