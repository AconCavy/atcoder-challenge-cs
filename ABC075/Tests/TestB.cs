using Microsoft.VisualStudio.TestTools.UnitTesting;
using B;

namespace Tests
{
    [TestClass]
    public class TestB
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 5
.....
.#.#.
.....";
            var output = @"11211
1#2#1
11211";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 5
#####
#####
#####";
            var output = @"#####
#####
#####";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6 6
#####.
#.#.##
####.#
.#..#.
#.##..
#.#...";
            var output = @"#####3
#8#7##
####5#
4#65#2
#5##21
#4#310";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
