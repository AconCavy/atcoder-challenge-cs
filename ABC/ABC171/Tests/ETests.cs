using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
20 11 9 24";
            var output = @"26 5 7 22";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
