using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"abcdef
2
3 5
1 4";
            var output = @"debacf";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"redcoat
3
1 7
1 2
3 4";
            var output = @"atcoder";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
