using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"5 -2 4
",
            @"-10 20
")]
        [TestCase(
            @"0 0 0
",
            @"0 0
")]
        public void SolverTest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 2 6 4
",
            @"2
")]
        [TestCase(
            @"3 3 100 0
",
            @"0
")]
        [TestCase(
            @"5 10 30 23
",
            @"2
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"123456789
",
            @"123b
")]
        [TestCase(
            @"77777
",
            @"77a
")]
        [TestCase(
            @"9982443539982448531000000007
",
            @"9i
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 3
50 80 60
60 70 70
",
            @"190
210
")]
        [TestCase(
            @"4 4
1 2 3 4
2 3 4 1
4 1 2 3
3 4 1 2
",
            @"10
13
15
16
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2022/01/01
",
            @"2022/02/02
")]
        [TestCase(
            @"2002/02/22
",
            @"2002/02/22
")]
        [TestCase(
            @"2002/02/23
",
            @"2020/02/02
")]
        [TestCase(
            @"2999/12/31
",
            @"3000/03/03
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 4 3
1 1 2 3
1 2 2 3
2 3 3
",
            @"No
")]
        [TestCase(
            @"3 5 4
1 1 1 3 2
1 2 1 3 4
1 1 1 3 2
3 1 4 3
",
            @"Yes
")]
        [TestCase(
            @"2 2 3
1 2
3 1
1 2 2
",
            @"Yes
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"32 2 -246
",
            @"1.500000000000000000
")]
        [TestCase(
            @"12 3 -45
",
            @"1.279562760087743278
")]
        public void GTest(string input, string output)
        {
            Utility.InOutTest(Tasks.G.Solve, input, output, 1e-9);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 7
1 1 2
2 2
1 3 4
2 5
1 1 4
2 1
2 4
",
            @"1 2
5
1 2 3 4
1 2 3 4
")]
        [TestCase(
            @"1 2
2 1
2 1
",
            @"1
1
")]
        [TestCase(
            @"3 3
1 1 2
2 1
1 1 2
",
            @"1 2
")]
        public void HTest(string input, string output)
        {
            Utility.InOutTest(Tasks.H.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
2 3
0 3
0 1
-1 3
1 1
1 3
",
            @"Yes
")]
        [TestCase(
            @"2
1 1
0 0
0 0
-1 -1
",
            @"No
")]
        [TestCase(
            @"3
3 1
4 1
5 9
5 9
3 1
4 1
",
            @"Yes
")]
        public void ITest(string input, string output)
        {
            Utility.InOutTest(Tasks.I.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 2
3 7 5
",
            @"665496238
")]
        [TestCase(
            @"3 1
3 7 5
",
            @"0
")]
        [TestCase(
            @"10 5
384 887 778 916 794 336 387 493 650 422
",
            @"621922587
")]
        public void JTest(string input, string output)
        {
            Utility.InOutTest(Tasks.J.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
1 2 3
2 3 4
1 3 2
",
            @"2
7
2
")]
        [TestCase(
            @"5 10
2 1 1
2 5 5
1 2 6
2 5 4
5 3 2
1 3 1
1 3 4
3 5 4
1 5 3
5 2 3
",
            @"3
10
5
-1
3
")]
        public void KTest(string input, string output)
        {
            Utility.InOutTest(Tasks.K.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 11
1 4
2 2
3 1
",
            @"3
")]
        [TestCase(
            @"2 10000
1 1
0 1000000000000
",
            @"0
")]
        [TestCase(
            @"8 5054049
1 41421356
1 7320508075
2 2360679
3 141592653589
0 57721566
1 644934066848
2 99792458
9 192631770
",
            @"3689688
")]
        public void LTest(string input, string output)
        {
            Utility.InOutTest(Tasks.L.Solve, input, output);
        }
    }
}
