using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2
1
1
2
3";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5
30
10
20
40
20
10
10
30
50
60";
            const string output = @"516";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }
    }
}
