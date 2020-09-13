using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"6
1 1 1 2 2 3
1 1 1 2 2 3";
            var output = @"Yes
2 2 3 1 1 1";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
1 1 2
1 1 3";
            var output = @"No";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4
1 1 2 3
1 2 3 3";
            var output = @"Yes
3 3 1 2";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }
    }
}
