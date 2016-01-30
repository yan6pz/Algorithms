using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knn
{
    class Item:IComparable<Item>
    {
        double distance;
        public string theClass;

        public Item(double distance, string theClass)
        {
            this.distance = distance;
            this.theClass = theClass;
        }

        public int CompareTo(Item other)
        {
           return this.distance.CompareTo(other.distance);
        }
    }
}
