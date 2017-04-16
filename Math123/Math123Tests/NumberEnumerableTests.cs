using NUnit.Framework;
using System.Linq;
using N = Math123.NumberEnumerable;

namespace Math123Tests
{
    [TestFixture]
    public class NumberEnumerableTests
    {
        [Test]
        public void TestTenPow()
        {
            Assert.AreEqual(1, N.TenPow(0));
            Assert.AreEqual(10, N.TenPow(1));
            Assert.AreEqual(100, N.TenPow(2));
            Assert.AreEqual(1000, N.TenPow(3));
            Assert.AreEqual(1000000, N.TenPow(6));
        }

        [Test]
        public void TestMakeNumbers()
        {
            var numbers = N.MakeNumbers(new[] { N.Digits, N.Digits, N.Digits }).ToList();

            Assert.AreEqual(1000, numbers.Count());
            for (int i = 0; i != 1000; ++i)
            {
                Assert.AreEqual(i, numbers[i]);
            }
        }

        [Test]
        public void TestMakeNumbersWithRestrictions()
        {
            var numbers = N.MakeNumbers(new[] { N.NonZeroDigits, N.Digits, N.Digits, N.D2, N.D3 }).ToList();

            Assert.AreEqual(900, numbers.Count());
            for (int i = 100; i != 1000; ++i)
            {
                Assert.AreEqual(i * 100 + 23, numbers[i-100]);
            }
        }
    }
}
