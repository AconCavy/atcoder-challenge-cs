using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"?tc????
coder";
            var output = @"atcoder";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"??p??d??
abc";
            var output = @"UNRESTORABLE";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"?tcoder
atcoder";
            var output = @"atcoder";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"atcoder
atcoder";
            var output = @"atcoder";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"atcode?
atcoder";
            var output = @"atcoder";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
