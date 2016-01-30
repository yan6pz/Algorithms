using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    class Program
    {
        private static Integer[] array = new Integer[] { new Integer(96), new Integer(82)
            , new Integer(93), new Integer(50), new Integer(71), new Integer(63), new Integer(37)
                , new Integer(31), new Integer(46), new Integer(29) };
        private static Integer[] arrayDel = new Integer[] { new Integer(84), new Integer(80)
            , new Integer(74), new Integer(36), new Integer(59), new Integer(50), new Integer(25)
                , new Integer(16), new Integer(33), new Integer(43) };

        static void Main(string[] args)
        {
            var heap = new BinaryHeap<Integer>(arrayDel.Length);
            foreach (var el in arrayDel)
            {
                heap.Insert(el);
            }
            heap.DeleteMax();
            heap.DeleteMax();
            heap.DeleteMax();
            foreach (var el in heap.PQ)
            {
                if (el != null)
                    Console.Write(el.data.ToString() + " ");
            }
            var heap1 = new BinaryHeap<Integer>(array.Length+3);
            foreach (var el in array)
            {
                heap1.Insert(el);
            }
            heap1.Insert(new Integer(55));
            heap1.Insert(new Integer(52));
            heap1.Insert(new Integer(57));
           
            foreach (var el in heap1.PQ)
            {
                if(el!=null)
                    Console.Write(el.data.ToString()+" ");
            }

        }
    }
}
