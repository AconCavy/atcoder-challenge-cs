using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"84 97 66
79 89 11
61 59 7
7
89
7
87
79
24
84
30";
            var output = @"Yes";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"41 7 46
26 89 2
78 92 8
5
6
45
16
57
17";
            var output = @"No";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"60 88 34
92 41 43
65 73 48
10
60
43
88
11
48
73
65
41
92
34";
            var output = @"Yes";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
