using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"8 1 3 5 7
1 2 3 4 5 6 7 8
",
            @"5 6 7 4 1 2 3 8
")]
        [TestCase(
            @"5 2 3 4 5
2 2 1 1 1
",
            @"2 1 1 2 1
")]
        [TestCase(
            @"2 1 1 2 2
50 100
",
            @"100 50
")]
        [TestCase(
            @"10 2 4 7 9
22 75 26 45 72 81 47 29 97 2
",
            @"22 47 29 97 72 81 75 26 45 2
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
naan
",
            @"nyaan
")]
        [TestCase(
            @"4
near
",
            @"near
")]
        [TestCase(
            @"8
national
",
            @"nyationyal
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 1 2
rrefa
",
            @"3
")]
        [TestCase(
            @"8 1000000000 1000000000
bcdfcgaa
",
            @"4000000000
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 19
2 3
5 6
",
            @"Yes
")]
        [TestCase(
            @"2 18
2 3
5 6
",
            @"No
")]
        [TestCase(
            @"3 1001
1 1
2 1
100 10
",
            @"Yes
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
30 50 70 20 60
NYYNN
NNYNN
NNNYY
YNNNN
YNNNN
3
1 3
3 1
4 5
",
            @"1 100
2 160
3 180
")]
        [TestCase(
            @"2
100 100
NN
NN
1
1 2
",
            @"Impossible
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
