using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4 4
##.#
....
##.#
.#.#";
            const string output = @"###
###
.##";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3 3
#..
.#.
..#";
            const string output = @"#..
.#.
..#";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"4 5
.....
.....
..#..
.....";
            const string output = @"#";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"7 6
......
....#.
.#....
..#...
..#...
......
.#..#.";
            const string output = @"..#
#..
.#.
.#.
#.#";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
