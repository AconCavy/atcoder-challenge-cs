using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3
atcodeer
codeforces
aaa";
            const string output = @"1
0
-1";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
