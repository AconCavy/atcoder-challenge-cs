using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 3
10 1
1
15 1
2
30 2
1 2";
            const string output = @"25";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"12 1
100000 1
2";
            const string output = @"-1";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"4 6
67786 3
1 3 4
3497 1
2
44908 3
2 3 4
2156 3
2 3 4
26230 1
2
86918 1
3";
            const string output = @"69942";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
