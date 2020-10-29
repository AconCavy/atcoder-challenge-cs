using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"25";
            const string output = @"Christmas";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"22";
            const string output = @"Christmas Eve Eve Eve";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
