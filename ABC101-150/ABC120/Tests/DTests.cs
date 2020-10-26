using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4 5
1 2
3 4
1 3
2 3
1 4";
            const string output = @"0
0
4
5
6";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"6 5
2 3
1 2
5 6
3 4
4 5";
            const string output = @"8
9
12
14
15";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"2 1
1 2";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
