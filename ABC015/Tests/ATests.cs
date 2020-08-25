using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"isuruu
isleapyear";
            var output = @"isleapyear";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"ttttiiiimmmmeeee
time";
            var output = @"ttttiiiimmmmeeee";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
