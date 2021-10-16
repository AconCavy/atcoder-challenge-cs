using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class HTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 3
1 1
..#
^^.
><.
";
            const string output = @"oo#
ooo
xxo
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 12
9 1
#.^<..><<...
#<>.#<^.<<.^
^.<>.^.^.^>.
^.>#^><#....
.>.^>#...<<>
....^^.#<.<.
.>^..^#><#.^
......#>....
..<#<...^>^.
<..^>^^...^<
";
            const string output = @"#xxxxxxxxxxx
#xxx#xxxxxxx
xooxxxxxxxxx
xox#xxx#xxxx
oooxx#xxxxxx
ooooxxx#xxxx
ooooox#xx#xx
oooooo#xxxxx
ooo#xoooxxxx
xooxooooooxx
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"15 20
13 9
####..<#^>#>.<<><^..
#.>#>.^#^.>><>...^..
>..<>.#.>.>.>...#..<
<^>.#..<>^#<#.>.<.^.
>#<^>.>#^>#^.^.#^><^
<^.^.#<...<.><#>...#
.<>....^..#>>#..>>><
.<#<^#.>#>^^.>.##.^<
.#.^.....<<#^#><^<<<
^.#>.#^.>.^.^<<>..><
.^#^<^^^<......^>.#^
.<..#>...^>^.^<..<.^
#.^.#..#.....>#.^^.>
.#^..>>><>>>^..#^.^^
.>#..<..<>.#>..^.#.^
";
            const string output = @"####xxx#xx#xxxxxxxxx
#xx#xxx#xxxxxxxxxxxx
xxxxxx#xxxxxxxxx#xxx
xxxx#xxxxx#x#xxxxxxx
x#xxxxx#xx#xxxx#xxxx
xxoxo#xxxxxxxx#xxxx#
xxoooooxxx#xx#xxxxxx
xx#xo#ox#xxxxxx##xxx
x#xxooooooo#x#xxxxxx
xx#oo#ooooooxxxoooxx
xx#ooxoooooooooooo#x
xxoo#oooooooooooooox
#ooo#oo#ooooox#oooox
x#oooxxxxoooooo#ooox
xx#oooooooo#oooxo#ox
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }
    }
}
