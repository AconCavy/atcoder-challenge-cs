using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 5
1 2 3 4 5
1 0 5
1 2 4
0 3 10
1 0 5
1 0 3";
            var output = @"15
7
25
6";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
