using Math123;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Math123Tests
{
    [TestFixture]
    public class RationalTests
    {
        [Test]
        public void TestContructor()
        {
            var r0 = new Rational();
            Assert.IsNotNull(r0);

            var f1 = new Rational(2, 4);
            Assert.AreEqual(1, f1.Numerator);
            Assert.AreEqual(2, f1.Denominator);

            var f2 = new Rational(2, -4);
            Assert.AreEqual(-1, f2.Numerator);
            Assert.AreEqual(2, f2.Denominator);

            var f3 = new Rational(10, 2);
            Assert.AreEqual(5, f3.Numerator);
            Assert.AreEqual(1, f3.Denominator);

            var f4 = new Rational(-10, 2);
            Assert.AreEqual(-5, f4.Numerator);
            Assert.AreEqual(1, f4.Denominator);

            var f5 = new Rational(10, -2);
            Assert.AreEqual(-5, f5.Numerator);
            Assert.AreEqual(1, f5.Denominator);

            var f6 = new Rational(-10, -2);
            Assert.AreEqual(5, f6.Numerator);
            Assert.AreEqual(1, f6.Denominator);

            var f7 = new Rational(0, 10);
            Assert.AreEqual(0, f7.Numerator);
            Assert.AreEqual(1, f7.Denominator);

            var f8 = new Rational(0);
            Assert.AreEqual(0, f8.Numerator);
            Assert.AreEqual(1, f8.Denominator);

            var f9 = new Rational(0, -10);
            Assert.AreEqual(0, f9.Numerator);
            Assert.AreEqual(1, f9.Denominator);

            var f10 = new Rational(5);
            Assert.AreEqual(5, f10.Numerator);
            Assert.AreEqual(1, f10.Denominator);

            Assert.Throws<ArgumentOutOfRangeException>(() => new Rational(1, 0));
        }

        [Test]
        public void TestParse()
        {
            Rational rational;

            Assert.IsTrue(Rational.TryParse("123", out rational));
            Assert.AreEqual(new Rational(123), rational);
            Debug.WriteLine(rational);

            Assert.IsTrue(Rational.TryParse("123/456", out rational));
            Assert.AreEqual(new Rational(123, 456), rational);

            Assert.IsTrue(Rational.TryParse("123 456/789", out rational));
            Assert.AreEqual(new Rational(123 * 789 + 456, 789), rational);

            Assert.IsTrue(Rational.TryParse("-123", out rational));
            Assert.AreEqual(new Rational(-123), rational);

            Assert.IsTrue(Rational.TryParse("-123/456", out rational));
            Assert.AreEqual(new Rational(-123, 456), rational);

            Assert.IsTrue(Rational.TryParse("-123 456/789", out rational));
            Assert.AreEqual(new Rational(-123 * 789 + 456, 789), rational);

            Assert.IsTrue(Rational.TryParse(" \t 123\t\t  \t", out rational));
            Assert.AreEqual(new Rational(123), rational);
            Debug.WriteLine(rational);

            Assert.IsTrue(Rational.TryParse(" \t123\t/ 456   \t", out rational));
            Assert.AreEqual(new Rational(123, 456), rational);

            Assert.IsTrue(Rational.TryParse("   123     456  /   789   ", out rational));
            Assert.AreEqual(new Rational(123 * 789 + 456, 789), rational);

            Assert.IsTrue(Rational.TryParse("  -123   ", out rational));
            Assert.AreEqual(new Rational(-123), rational);

            Assert.IsTrue(Rational.TryParse("  -123  /   456  ", out rational));
            Assert.AreEqual(new Rational(-123, 456), rational);

            Assert.IsTrue(Rational.TryParse("   -123    456   /   789  ", out rational));
            Assert.AreEqual(new Rational(-123 * 789 + 456, 789), rational);
        }

        [Test]
        public void TestAdd()
        {
            var result = new Rational(1, 2) + new Rational(1, 4);
            Assert.AreEqual(new Rational(3, 4), result);

            result = new Rational(1, 2) + 1;
            Assert.AreEqual(new Rational(3, 2), result);

            result = 2 + new Rational(1, 2);
            Assert.AreEqual(new Rational(5, 2), result);

            Assert.Throws<OverflowException>(() =>
            {
                result = new Rational(1) + long.MaxValue;
            });
        }

        [Test]
        public void TestSubtract()
        {
            var result = new Rational(1, 2) - new Rational(1, 4);
            Assert.AreEqual(new Rational(1, 4), result);

            result = new Rational(1, 2) - 1;
            Assert.AreEqual(new Rational(-1, 2), result);

            result = 2 - new Rational(1, 2);
            Assert.AreEqual(new Rational(3, 2), result);

            Assert.Throws<OverflowException>(() =>
            {
                result = new Rational(-1) - long.MinValue;
            });
        }

        [Test]
        public void TestMultiply()
        {
            var result = new Rational(1, 2) * new Rational(1, 4);
            Assert.AreEqual(new Rational(1, 8), result);

            result = new Rational(1, 2) * 2;
            Assert.AreEqual(new Rational(1), result);

            result = 3 * new Rational(1, 4);
            Assert.AreEqual(new Rational(3, 4), result);

            Assert.Throws<OverflowException>(() =>
            {
                result = new Rational(2) * long.MaxValue;
            });
        }

        [Test]
        public void TestDivide()
        {
            var result = new Rational(1, 2) / new Rational(1, 4);
            Assert.AreEqual(new Rational(2), result);

            result = new Rational(1, 2) / 2;
            Assert.AreEqual(new Rational(1, 4), result);

            result = 3 / new Rational(1, 4);
            Assert.AreEqual(new Rational(12), result);

            Assert.Throws<OverflowException>(() =>
            {
                result = new Rational(1, long.MaxValue) / long.MaxValue;
            });
        }

        [Test]
        public void TestCast()
        {
            Rational f1 = 5;
            Assert.AreEqual(5, f1.Numerator);
            Assert.AreEqual(1, f1.Denominator);

            Rational f2 = -5;
            Assert.AreEqual(-5, f2.Numerator);
            Assert.AreEqual(1, f2.Denominator);

            var i1 = (int)new Rational(1, 2);
            Assert.AreEqual(0, i1);

            var i2 = (int)new Rational(3, 2);
            Assert.AreEqual(1, i2);

            var d1 = (double)new Rational(1, 2);
            Assert.AreEqual(0.5, d1, 0.0000001);

            var d2 = (double)new Rational(3, 2);
            Assert.AreEqual(1.5, d2, 0.0000001);

            var d3 = (double)new Rational(1, 3);
            Assert.AreEqual(0.3333333333333, d3, 0.0000001);

            var f3 = Rational.FromDouble(0.5, 8);

            var f4 = Rational.FromDouble(1.0 / 3.0, 8);
            Assert.AreEqual(1, f4.Numerator);
            Assert.AreEqual(3, f4.Denominator);

            var f5 = Rational.FromDouble(1.0 / 2.0, 8);
            Assert.AreEqual(1, f5.Numerator);
            Assert.AreEqual(2, f5.Denominator);
        }

        [Test]
        public void TestRound()
        {
            var validDenominators = new[] { 2L, 3L, 4L, 5L, 6L, 8L, 12L, 16L };

            var oneThird = new Rational(1, 3);
            var almostOneThird = oneThird + new Rational(1, 100000);
            Assert.AreEqual(oneThird, almostOneThird.Round(validDenominators));

            var oneFifth = new Rational(1, 5);
            var almostOneFifth = oneFifth + new Rational(1, 100000);
            Assert.AreEqual(oneFifth, almostOneFifth.Round(validDenominators));

            var oneHalf = new Rational(1, 2);
            var almostOneHalf = oneHalf + new Rational(1, 100000);
            Assert.AreEqual(oneHalf, almostOneHalf.Round(validDenominators));
        }

        [Test]
        public void TestPreIncrement()
        {
            var r1 = new Rational(1, 7);
            var r2 = ++r1;
            Assert.AreEqual(8, r1.Numerator);
            Assert.AreEqual(7, r1.Denominator);
            Assert.AreEqual(8, r2.Numerator);
            Assert.AreEqual(7, r2.Denominator);
        }

        [Test]
        public void TestPostIncrement()
        {
            var r1 = new Rational(1, 7);
            var r2 = r1++;
            Assert.AreEqual(8, r1.Numerator);
            Assert.AreEqual(7, r1.Denominator);
            Assert.AreEqual(1, r2.Numerator);
            Assert.AreEqual(7, r2.Denominator);
        }
    }
}