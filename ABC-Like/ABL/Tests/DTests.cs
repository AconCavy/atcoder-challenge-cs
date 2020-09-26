using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"10 3
1
5
4
3
8
6
9
7
2
4";
            const string output = @"7";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
