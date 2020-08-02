using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"25";
            var output = @"No";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
