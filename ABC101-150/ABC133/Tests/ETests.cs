using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4 3
1 2
2 3
3 4";
            const string output = @"6";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5 4
1 2
1 3
1 4
4 5";
            const string output = @"48";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"16 22
12 1
3 1
4 16
7 12
6 2
2 15
5 16
14 16
10 11
3 10
3 13
8 6
16 8
9 12
4 3";
            const string output = @"271414432";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
