using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"ant
obe
rec";
            var output = @"abc";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"edu
cat
ion";
            var output = @"ean";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
