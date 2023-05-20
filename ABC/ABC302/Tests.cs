using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"7 3
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"123456789123456789 987654321
",
            @"124999999
",
            TestName = "{m}-2")]
        [TestCase(
            @"999999999999999998 2
",
            @"499999999999999999
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6 6
vgxgpu
amkxks
zhkbpp
hykink
esnuke
zplvfj
",
            @"5 2
5 3
5 4
5 5
5 6
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 5
ezzzz
zkzzz
ezuzs
zzznz
zzzzs
",
            @"5 5
4 4
3 3
2 2
1 1
",
            TestName = "{m}-2")]
        [TestCase(
            @"10 10
kseeusenuk
usesenesnn
kskekeeses
nesnusnkkn
snenuuenke
kukknkeuss
neunnennue
sknuessuku
nksneekknk
neeeuknenk
",
            @"9 3
8 3
7 3
6 3
5 3
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 4
bbed
abcd
abed
fbed
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"2 5
abcde
abced
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"8 4
fast
face
cast
race
fact
rice
nice
case
",
            @"Yes
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 3 2
3 10
2 5 15
",
            @"8
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 3 0
1 3 3
6 2 7
",
            @"-1
",
            TestName = "{m}-2")]
        [TestCase(
            @"1 1 1000000000000000000
1000000000000000000
1000000000000000000
",
            @"2000000000000000000
",
            TestName = "{m}-3")]
        [TestCase(
            @"8 6 1
2 5 6 5 2 1 7 9
7 2 5 5 2 4
",
            @"14
",
            TestName = "{m}-4")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 7
1 1 2
1 1 3
1 2 3
2 1
1 1 2
2 2
1 1 2
",
            @"1
0
0
1
0
3
1
",
            TestName = "{m}-1")]
        [TestCase(
            @"2 1
2 1
",
            @"2
",
            TestName = "{m}-2")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(3000)]
        [TestCase(
            @"3 5
2
1 2
2
2 3
3
3 4 5
",
            @"2
",
            TestName = "{m}-1")]
        [TestCase(
            @"1 2
2
1 2
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"3 5
2
1 3
2
2 4
3
2 4 5
",
            @"-1
",
            TestName = "{m}-3")]
        [TestCase(
            @"4 8
3
1 3 5
2
1 2
3
2 4 7
4
4 6 7 8
",
            @"2
",
            TestName = "{m}-4")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6
3 4 1 1 2 4
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"4
2 3 4 1
",
            @"3
",
            TestName = "{m}-2")]
        public void GTest(string input, string output)
        {
            Utility.InOutTest(Tasks.G.Solve, input, output);
        }
    }
}
