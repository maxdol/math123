namespace Math123
{
    // thanks to Rob Blackbourn http://geekswithblogs.net/blackrob/archive/2014/11/14/a-rational-number-class-in-c.aspx
    public static class Algorithms
    {
        public static int GreatestCommonDivisor(int a, int b)
        {
            bool aneg = a < 0, bneg = b < 0;
            if (aneg) a = -a;
            if (bneg) b = -b;

            var gcd = (int)GreatestCommonDivisor((ulong)a, (ulong)b);
            return aneg == bneg ? gcd : -gcd;
        }

        /// <summary>
        /// greatest common divisor
        /// </summary>
        public static long GreatestCommonDivisor(long a, long b)
        {
            bool aneg = a < 0, bneg = b < 0;
            if (aneg) a = -a;
            if (bneg) b = -b;

            var gcd = GreatestCommonDivisor((ulong)a, (ulong)b);
            return aneg == bneg ? (long)gcd : -((long)gcd);
        }

        /// <summary>
        /// greatest common divisor
        /// </summary>
        public static ulong GreatestCommonDivisor(ulong a, ulong b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        public static int LeastCommonMultiple(int a, int b)
        {
            int temp = GreatestCommonDivisor(a, b);

            return temp != 0 ? (a / temp * b) : 0;
        }
    }
}