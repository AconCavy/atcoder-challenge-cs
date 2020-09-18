using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 3
...
...
...";
            var output = @"4";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 5
...#.
.#.#.
.#...";
            var output = @"10";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
