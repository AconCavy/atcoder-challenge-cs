using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"0 3 1 5
",
            @"2
")]
        [TestCase(
            @"0 1 4 5
",
            @"0
")]
        [TestCase(
            @"0 3 3 7
",
            @"0
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
-WWW
L-DD
LD-W
LDW-
",
            @"incorrect
")]
        [TestCase(
            @"2
-D
D-
",
            @"correct
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
newfile
newfile
newfolder
newfile
newfolder
",
            @"newfile
newfile(1)
newfolder
newfile(2)
newfolder(1)
")]
        [TestCase(
            @"11
a
a
a
a
a
a
a
a
a
a
a
",
            @"a
a(1)
a(2)
a(3)
a(4)
a(5)
a(6)
a(7)
a(8)
a(9)
a(10)
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6 3
2 7 1 8 2 8
2 10
3 1
5 5
",
            @"48
")]
        [TestCase(
            @"3 2
1000000000 1000000000 1000000000
1 1000000000
3 1000000000
",
            @"5000000000
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 10
3 3
2 5
1 12
",
            @"9
15
12
")]
        [TestCase(
            @"9 12
1 1
2 2
3 3
1 4
2 5
3 6
1 7
2 8
3 9
",
            @"0
2
1
0
5
3
3
11
2
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
1 5 2 2 1
3 2 1 2 1
",
            @"6
")]
        [TestCase(
            @"3
1 1 1
3 2 1
",
            @"0
")]
        [TestCase(
            @"3
3 1 2
1 1 2
",
            @"0
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
