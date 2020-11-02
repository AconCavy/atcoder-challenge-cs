using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"azzel
apple";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"chokudai
redcoder";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"abcdefghijklmnopqrstuvwxyz
ibyhqfrekavclxjstdwgpzmonu";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
