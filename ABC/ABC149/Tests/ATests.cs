using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"oder atc";
            const string output = @"atcoder";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"humu humu";
            const string output = @"humuhumu";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
