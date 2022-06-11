using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"1 2
1 0
0 1
",
            @"0
")]
        [TestCase(
            @"2 2
1 2
3 4
",
            @"4
")]
        [TestCase(
            @"2 1
90 80
70 60
",
            @"70
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output, 1e-9);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 2
2 3
0 0
0 1
1 2
2 0
",
            @"2.23606797749978969
")]
        [TestCase(
            @"2 1
2
-100000 -100000
100000 100000
",
            @"282842.712474619009
")]
        [TestCase(
            @"8 3
2 6 8
-17683 17993
93038 47074
58079 -57520
-41515 -89802
-72739 68805
24324 -73073
71049 72103
47863 19268
",
            @"130379.280458974768
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output, 1e-5);
        }

        [Timeout(2000)]
        [TestCase(
            @"6 2 3 3
",
            @"1
")]
        [TestCase(
            @"0 0 0 1
",
            @"0
")]
        [TestCase(
            @"998244353 -10 -20 30
",
            @"998244363
")]
        [TestCase(
            @"-555555555555555555 -1000000000000000000 1000000 1000000000000
",
            @"444445
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 3
6 11 2 5 5
5
20
0
",
            @"10
71
29
")]
        [TestCase(
            @"10 5
1000000000 314159265 271828182 141421356 161803398 0 777777777 255255255 536870912 998244353
555555555
321654987
1000000000
789456123
0
",
            @"3316905982
2811735560
5542639502
4275864946
4457360498
")]
        public void taskTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"9 2
2 3 3 4 -4 -7 -4 -1
-1 5
",
            @"4
")]
        [TestCase(
            @"20 10
-183260318 206417795 409343217 238245886 138964265 -415224774 -499400499 -313180261 283784093 498751662 668946791 965735441 382033304 177367159 31017484 27914238 757966050 878978971 73210901
-470019195 -379631053 -287722161 -231146414 -84796739 328710269 355719851 416979387 431167199 498905398
",
            @"8
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
