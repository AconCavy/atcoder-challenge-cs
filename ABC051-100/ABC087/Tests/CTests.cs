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
3 2 2 4 1
1 2 2 2 1";
            var output = @"14";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
1 1 1 1
1 1 1 1";
            var output = @"5";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"7
3 3 4 5 4 5 3
5 3 4 4 2 3 2";
            var output = @"29";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"1
2
3";
            var output = @"5";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
