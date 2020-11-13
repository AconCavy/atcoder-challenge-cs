using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4
0 1
0 2
0 3
1 1";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"14
5 5
0 1
2 5
8 0
2 1
0 0
3 6
8 6
5 9
7 9
3 4
9 2
9 8
7 2";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"9
8 2
2 3
1 3
3 7
1 0
8 8
5 6
9 7
0 1";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
