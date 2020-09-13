using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class JTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 5
1 2 3 2 1
2 1 5
3 2 3
1 3 1
2 2 4
3 1 3";
            var output = @"3
3
2
6";
            Tester.InOutTest(() => Tasks.J.Solve(), input, output);
        }
    }
}
