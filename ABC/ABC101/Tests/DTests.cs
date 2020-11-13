using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"10";
            const string output = @"1
2
3
4
5
6
7
8
9
19";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
