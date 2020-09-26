using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3";
            const string output = @"ACLACLACL";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
