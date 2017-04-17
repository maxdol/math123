using System.Collections.Generic;

namespace Math123
{
    public static class BaseSequences
    {
        public static IEnumerable<int> NaturalNumbers
        {
            get
            {
                for (int i = 1;; ++i)
                    yield return i;
            }
        }

        public static IEnumerable<long> LongNaturalNumbers
        {
            get
            {
                for (long i = 1; ; ++i)
                    yield return i;
            }
        }
    }
}
