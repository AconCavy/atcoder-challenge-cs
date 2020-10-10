using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"Y
a";
            const string output = @"A";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"N
b";
            const string output = @"b";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
