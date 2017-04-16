using System;
using System.Collections.Generic;
using System.Linq;

namespace Math123
{
    public static class NumberEnumerable
    {
        #region Single Digits
        public static IEnumerable<long> D0 => Enumerable.Range(0, 1).Select(i => (long)i);
        public static IEnumerable<long> D1 => Enumerable.Range(1, 1).Select(i => (long)i);
        public static IEnumerable<long> D2 => Enumerable.Range(2, 1).Select(i => (long)i);
        public static IEnumerable<long> D3 => Enumerable.Range(3, 1).Select(i => (long)i);
        public static IEnumerable<long> D4 => Enumerable.Range(4, 1).Select(i => (long)i);
        public static IEnumerable<long> D5 => Enumerable.Range(5, 1).Select(i => (long)i);
        public static IEnumerable<long> D6 => Enumerable.Range(6, 1).Select(i => (long)i);
        public static IEnumerable<long> D7 => Enumerable.Range(7, 1).Select(i => (long)i);
        public static IEnumerable<long> D8 => Enumerable.Range(8, 1).Select(i => (long)i);
        public static IEnumerable<long> D9 => Enumerable.Range(9, 1).Select(i => (long)i);
        #endregion


        public static IEnumerable<long> Digits => Enumerable.Range(0, 10).Select(i => (long)i);
        public static IEnumerable<long> NonZeroDigits => Enumerable.Range(1, 9).Select(i => (long)i);

        public static IEnumerable<long> MakeNumbers(IEnumerable<IEnumerable<long>> digits)
        {
            var d = digits.ToList();
            var count = d.Count;

            return MakeNumbersReq(d.Select((r, i) => new Tuple<long, IEnumerable<long>>(TenPow(count - i - 1), r)));
        }

        public static long TenPow(int i)
        {
            if (i == 0)
                return 1;

            return Enumerable.Range(1, i).Select(x => 10).Aggregate(1, (res, x) => res * x);
        }


        private static IEnumerable<long> MakeNumbersReq(IEnumerable<Tuple<long, IEnumerable<long>>> digits)
        {
            var first = digits.First();
            var rest = digits.Skip(1);
            if (rest.Any())
            {
                foreach (var d1 in first.Item2)
                {
                    foreach (var restPart in MakeNumbersReq(rest))
                    {
                        yield return first.Item1 * d1 + restPart;
                    }
                }
            }
            else
            {
                foreach (var i in first.Item2)
                {
                    yield return i;
                }
            }
        }
    }
}
