using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"ch@ku@ai
choku@@i";
            var output = @"You can win";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"aoki
@ok@";
            var output = @"You will lose";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"arc
abc";
            var output = @"You will lose";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
