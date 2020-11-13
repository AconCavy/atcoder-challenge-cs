using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"10
1 2 5 3 4 6 7 3 2 4
1 2
2 3
3 4
4 5
3 6
6 7
1 8
8 9
9 10";
            const string output = @"1
2
3
3
4
4
5
2
2
3";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }
    }
}
