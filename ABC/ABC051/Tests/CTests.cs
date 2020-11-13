using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"0 0 1 2";
            var output = @"UURDDLLUUURRDRDDDLLU";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"-2 -2 1 1";
            var output = @"UUURRRDDDLLLLUUUURRRRDRDDDDLLLLU";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
