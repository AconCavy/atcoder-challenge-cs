using Microsoft.VisualStudio.TestTools.UnitTesting;
using C;

namespace Tests
{
    [TestClass]
    public class TestC
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"6 3 4
3
1
3
2";
            var output = @"No
No
Yes
No
No
No";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6 5 4
3
1
3
2";
            var output = @"Yes
Yes
Yes
Yes
Yes
Yes";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10 13 15
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
            var output = @"No
No
No
No
Yes
No
No
No
Yes
No";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
