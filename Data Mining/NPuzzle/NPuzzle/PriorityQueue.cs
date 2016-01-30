using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPuzzle
{
    public class PriorityQueue<T> where T :IComparable<T>
    {
       
        private List<T> elements = new List<T>();
        //public int Priority { get; set; }

        public PriorityQueue()
        {

        }
        public int Count
        {
            get { return elements.Count; }
        }

        public void Clear()
        {
            elements = new List<T>();
        }

        public void Enqueue(T item)
        {
            elements.Add(item);
        }

        public T Dequeue()
        {
            int bestIndex = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].CompareTo(elements[bestIndex])<0)
                {
                    bestIndex = i;
                }
            }

            T bestItem = elements[bestIndex];
            elements.RemoveAt(bestIndex);
            return bestItem;
        }

        
    }
}
