using Math123;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Math123Tests
{
    [TestFixture]
    public class PrimeNumbersTest
    {
        [Test]
        public void TestPrimes()
        {
            var primes = new[] {1, 2, 3, 5, 7, 11, 13};

            foreach (var i in primes)
            {
                var list = i.GetPrimeNumbers().ToList();
                Assert.AreEqual(1, list.Count());
                Assert.AreEqual(i, list.Single());
            }
        }

        [Test]
        public void TestNaturals()
        {
            foreach (var i in BaseSequences.NaturalNumbers.Take(100000))
            {
                var direct = i.GetPrimeNumbersDirect().ToList();
                var fast = i.GetPrimeNumbers().ToList();
                bool isPrimeDirect = i.IsPrimeDirect();
                bool isPrimeFast = i.IsPrime();

                Assert.IsTrue(isPrimeDirect == isPrimeFast,
                    $"{i} -> [{direct.FoldToString()}] is Prime {isPrimeDirect} != {isPrimeFast}");

                Assert.IsTrue(direct.Count == fast.Count,
                    $"{i} -> [{direct.FoldToString()}] factorization {direct.Any()} != {fast.Any()}");

                Assert.IsTrue(isPrimeFast == (fast.Count == 1),
                    $"{i} -> [{direct.FoldToString()}] factorization {direct.Any()} != {fast.Any()}");

                Assert.IsTrue(direct.SequenceEqual(fast),
                    $"{i} -> factorization [{direct.FoldToString()}] != [{fast.FoldToString()}]");

                Assert.AreEqual(i, fast.Aggregate(1, (res, x) => res * x));
            }
        }

        [Test]
        public void TestNaturalsTrace()
        {
            Trace.TraceInformation(BaseSequences.NaturalNumbers.Where(i => i.IsPrimeDirect()).TakeWhile(i => i < 1000000).FoldToString());
        }

        [Test]
        public void TestNonPrimes()
        {
            TestPrimeNumbersFactorization(4, new[] { 2, 2 });
            TestPrimeNumbersFactorization(6, new[] { 2, 3 });
            TestPrimeNumbersFactorization(10, new[] { 2, 5 });
            TestPrimeNumbersFactorization(12, new[] { 2, 2, 3 });
            TestPrimeNumbersFactorization(15, new[] { 3, 5 });
            TestPrimeNumbersFactorization(144, Enumerable.Repeat(2, 4).Concat(Enumerable.Repeat(3, 2)));
            TestPrimeNumbersFactorization(239, new[] { 239 });
            TestPrimeNumbersFactorization(1024, Enumerable.Repeat(2, 10));
            TestPrimeNumbersFactorization(10013, new[] { 17, 19, 31 });
        }

        private static void TestPrimeNumbersFactorization(int x, IEnumerable<int> expectedPrimes)
        {
            var expected = expectedPrimes.ToList();
            var primes = x.GetPrimeNumbers();
            Assert.IsTrue(x.GetPrimeNumbers().SequenceEqual(expected), $"[{primes.FoldToString()}] != [{expected.FoldToString()}]");
        }

        [Test]
        public void TestLeastCommonMultiple()
        {
            Assert.AreEqual(15, Algorithms.LeastCommonMultiple(3, 5));
            Assert.AreEqual(36, Algorithms.LeastCommonMultiple(12, 9));
            Assert.AreEqual(36, Algorithms.LeastCommonMultiple(36, 9));
            Assert.AreEqual(2 * 2 * 3 * 7 * 11 * 13 * 41 * 37, Algorithms.LeastCommonMultiple(2 * 2 * 3 * 13 * 41, 
                                                                                              2 * 3 * 7 * 11  * 37));
        }

        [Test]
        public void TestGreatestCommonDivisor()
        {
            Assert.AreEqual(4 , Algorithms.GreatestCommonDivisor(12, 8));
            Assert.AreEqual(21, Algorithms.GreatestCommonDivisor(462, 1071));
        }
    }
}
