using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"ABC";
            const string output = @"ARC";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
