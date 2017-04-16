namespace Math123
{
    // thanks to Rob Blackbourn http://geekswithblogs.net/blackrob/archive/2014/11/14/a-rational-number-class-in-c.aspx
    public static class Algorithms
    {
        /// <summary>
        /// greatest common divisor
        /// </summary>
        public static long Gcd(long a, long b)
        {
            bool aneg = a < 0, bneg = b < 0;
            if (aneg) a = -a;
            if (bneg) b = -b;

            var gcd = Gcd((ulong)a, (ulong)b);
            return aneg == bneg ? (long)gcd : -((long)gcd);
        }

        /// <summary>
        /// greatest common divisor
        /// </summary>
        public static ulong Gcd(ulong a, ulong b)
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
    }
}