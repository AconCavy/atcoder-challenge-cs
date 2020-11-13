using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
2 4 4 3";
            var output = @"4
3
3
4";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2
1 2";
            var output = @"2
1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6
5 5 4 4 3 3";
            var output = @"4
4
4
4
4
4";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"6
1 2 3 4 5 6";
            var output = @"4
4
4
3
3
3";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
