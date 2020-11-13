using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 4
1 2 2000
2 3 2004
3 4 1999
4 5 2001
3
1 2000
1 1999
3 1995";
            var output = @"1
3
5";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 5
1 2 2005
3 1 2001
3 4 2002
1 4 2004
4 2 2003
5
1 2003
2 2003
1 2001
3 2003
4 2004";
            var output = @"3
3
4
1
1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4 5
1 2 10
1 2 1000
2 3 10000
2 3 100000
3 1 200000
4
1 0
2 10000
3 100000
4 0";
            var output = @"3
3
2
1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
