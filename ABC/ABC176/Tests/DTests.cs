using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 4
1 1
4 4
..#.
..#.
.#..
.#..";
            var output = @"1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 4
1 4
4 1
.##.
####
####
.##.";
            var output = @"-1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4 4
2 2
3 3
....
....
....
....";
            var output = @"0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"4 5
1 2
2 5
#.###
####.
#..##
#..##";
            var output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"5 5
1 1
5 5
.#.#.
#.#.#
.#.#.
#.#.#
.#.#.";
            var output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
