using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 3
#..
..#
...";
            var output = @"3
#><
><#
><.";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
