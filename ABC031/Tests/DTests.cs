using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"6 4
356 migoro
461 yoroi
2 ni
12 ini";
            var output = @"i
ni
mi
yo
go
ro";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 4
21 aaa
12 aaa
123 aaaaaa
13 aaaa";
            var output = @"a
aa
aaa";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"2 3
12211 abcaaaaabcabc
2121 aaabcaaabc
222221 aaaaaaaaaaabc";
            var output = @"abc
aa";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"2 1
12 abcab";
            var output = @"ab
cab";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
