using System.Collections.Generic;
using System.Linq;

namespace Math123
{
    public static class BaseSequencesExtensions
    {
        public static string FoldToString<T>(this IEnumerable<T> seq, string sep = ", ", string head = "", string tail = "")
        {
            var s = seq.SelectMany((x, i) => (i != 0) ? new[] { sep, x.ToString() } : new[] { x.ToString() });

            return s.Aggregate(head, (str, x) => str + x) + tail;
        }
    }
}