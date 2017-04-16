using System.Collections.Generic;
using System.Linq;

namespace Math123
{
    public static class NumberExtensions
    {
        public static int Factorial(this int x )
        {
            return Enumerable.Range(1, x).Aggregate(1, (f, i) => f*i);
        }

        public static long Factorial(this long x)
        {
            return Enumerable.Range(1, (int)x).Select(i=>(long)i).Aggregate(1L, (f, i) => f * i);
        }

        public static IEnumerable<int> Digits(this int x)
        {
            for (int i = x; i != 0; i = (i - i%10)/10)
            {
                yield return i%10;
            }
        }
        public static IEnumerable<long> Digits(this long x)
        {
            for (long i = x; i != 0; i = (i - i % 10) / 10)
            {
                yield return i % 10;
            }
        }

    }
}
