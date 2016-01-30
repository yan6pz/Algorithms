using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class Integer : IComparer, IComparable
    {
        public int data { get; set; }
        public Integer(int data1)
        {
            data = data1;
        }

        public int Compare(object x, object y)
        {
            var a = (Integer)x;
            var b = (Integer)y;
            if (a.data > b.data)
                return 1;
            if (a.data < b.data)
                return -1;
            return 0;
        }

        public int CompareTo(object obj)
        {
            var a = (Integer)obj;
            return Compare(this, a);
        }
        public override string ToString()
        {
            return data.ToString();
        }
    }
}
