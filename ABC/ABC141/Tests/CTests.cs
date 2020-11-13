using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"6 3 4
3
1
3
2";
            const string output = @"No
No
Yes
No
No
No";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"6 5 4
3
1
3
2";
            const string output = @"Yes
Yes
Yes
Yes
Yes
Yes";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"10 13 15
3
1
4
1
5
9
2
6
5
3
5
8
9
7
9";
            const string output = @"No
No
No
No
Yes
No
No
No
Yes
No";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
