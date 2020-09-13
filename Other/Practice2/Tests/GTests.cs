using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class GTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"6 7
1 4
5 2
3 0
5 5
4 1
0 3
4 2";
            var output = @"4
1 5
2 1 4
1 2
2 0 3";
            Tester.InOutTest(() => Tasks.G.Solve(), input, output);
        }
    }
}
