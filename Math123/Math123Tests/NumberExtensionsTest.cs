using Math123;
using NUnit.Framework;
using System.Linq;
using Assert = NUnit.Framework.Assert;

namespace Math123Tests
{
    [TestFixture]
    public class NumberExtensiondTest
    {
        [Test]
        public void TestFactorial1()
        {
            Assert.AreEqual(1, 0.Factorial());
            Assert.AreEqual(1, 1.Factorial());
            Assert.AreEqual(2, 2.Factorial());
            Assert.AreEqual(6, 3.Factorial());
            Assert.AreEqual(24, 4.Factorial());
        }

        [Test]
        public void TestFactorial2()
        {
            int f = 1;
            for (int i = 0; i != 12; ++i, f *= i)
            {
                Assert.AreEqual(f, i.Factorial());
            }
        }

        [Test]
        public void DigitsTest()
        {
            Assert.IsTrue(123.Digits().SequenceEqual(new []{3, 2, 1}));
        }
    }
}

