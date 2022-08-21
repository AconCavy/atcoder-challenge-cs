using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"10 25 10
",
            @"85
")]
        [TestCase(
            @"10 40 10
",
            @"100
")]
        [TestCase(
            @"100 100 2
",
            @"200
")]
        [TestCase(
            @"100 100 100
",
            @"3400
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 1 10
5 7 5
2 10
",
            @"Yes
")]
        [TestCase(
            @"4 1 10
10 7 5
2 10
",
            @"No
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 3
RDU
LRU
",
            @"1 3
")]
        [TestCase(
            @"2 3
RRD
ULL
",
            @"-1
")]
        [TestCase(
            @"9 44
RRDDDDRRRDDDRRRRRRDDDRDDDDRDDRDDDDDDRRDRRRRR
RRRDLRDRDLLLLRDRRLLLDDRDLLLRDDDLLLDRRLLLLLDD
DRDLRLDRDLRDRLDRLRDDLDDLRDRLDRLDDRLRRLRRRDRR
DDLRRDLDDLDDRLDDLDRDDRDDDDRLRRLRDDRRRLDRDRDD
RDLRRDLRDLLLLRRDLRDRRDRRRDLRDDLLLLDDDLLLLRDR
RDLLLLLRDLRDRLDDLDDRDRRDRLDRRRLDDDLDDDRDDLDR
RDLRRDLDDLRDRLRDLDDDLDDRLDRDRDLDRDLDDLRRDLRR
RDLDRRLDRLLLLDRDRLLLRDDLLLLLRDRLLLRRRRLLLDDR
RRRRDRDDRRRDDRDDDRRRDRDRDRDRRRRRRDDDRDDDDRRR
",
            @"9 5
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"10 5 7 5
1 3 2 2 2 3 1 4 3 2
",
            @"Yes
")]
        [TestCase(
            @"9 100 101 100
31 41 59 26 53 58 97 93 23
",
            @"No
")]
        [TestCase(
            @"7 1 1 1
1 1 1 1 1 1 1
",
            @"Yes
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(3000)]
        [TestCase(
            @"2 2
1 1 1 2 1 3
1 2
2 2
",
            @"5
")]
        [TestCase(
            @"10 3
-1000000000 -1000000000 1000000000 1000000000 -1000000000 1000000000
-1000000000 -1000000000
1000000000 1000000000
-1000000000 1000000000
",
            @"0
")]
        [TestCase(
            @"300 0
0 0 1 0 0 1
",
            @"292172978
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(6000)]
        [TestCase(
            @"1 5
0
3
",
            @"8
")]
        [TestCase(
            @"3 10
2 6 5
2 1 2
",
            @"632
")]
        [TestCase(
            @"10 100
3 1 4 1 5 9 2 6 5 3
2 7 1 8 2 8 1 8 2 8
",
            @"145428186
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
