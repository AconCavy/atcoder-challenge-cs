using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4 4
1 2
2 3
3 4
4 2";
            const string output = @"Yes
1
2
2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"6 9
3 4
6 1
2 4
5 3
4 6
1 5
6 2
4 5
5 6";
            const string output = @"Yes
6
5
6
1
1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
