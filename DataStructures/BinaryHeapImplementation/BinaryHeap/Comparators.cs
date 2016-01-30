using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public static class Comparators
    {
        private static bool CompareTo(this BinaryHeap<Integer> a, IComparable el1, IComparable el2)
        {
            var result = el1.CompareTo(el2);
            return result < 0;
        }
    }
}
