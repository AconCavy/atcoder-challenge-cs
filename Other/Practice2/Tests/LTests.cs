using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class LTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 5
0 1 0 0 1
2 1 5
1 3 4
2 2 5
1 1 3
2 1 2";
            var output = @"2
0
1";
            Tester.InOutTest(() => Tasks.L.Solve(), input, output);
        }
    }
}
