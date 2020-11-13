using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 4
2 4
1 1
2 3
2 4";
            var output = @"1
3
6
-1";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"3 3
1 1
2 2
3 3";
            var output = @"1
2
-1";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }
    }
}
