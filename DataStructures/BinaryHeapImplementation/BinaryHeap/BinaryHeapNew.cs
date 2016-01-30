using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class BinaryHeapNew<T>
    {
        protected T[] _data;

        protected int _size = 0;


        public BinaryHeapNew()
        {
            _data = new T[4];
        }


        //public BinaryHeapNew(int capacity)
        //{
        //    Constructor(capacity, null);
        //}

        //public BinaryHeapNew(int capacity, Comparison comparison)
        //{
        //    Constructor(capacity, comparison);
        //}

        private void Constructor(int capacity)
        {
           
            //_comparison = comparison;
            //if (_comparison == null)
            //    _comparison = new Comparison(Comparer.Default.Compare);
        }

        public int Size
        {
            get { return _size; }
        }

        ///
        /// Add an item to the heap
        ///
        public void Insert(T item)
        {
            if (_size == _data.Length)
                Resize();
            _data[_size] = item;
            //HeapifyUp(_size);
            _size++;
        }

        ///
        /// Get the item of the root
        ///
        public T Peak()
        {
            return _data[0];
        }

        ///
        /// Extract the item of the root
        ///
        public T Pop()
        {
            T item = _data[0];
            _size--;
            _data[0] = _data[_size];
            //HeapifyDown(0);
            return item;
        }

        private void Resize()
        {
            T[] resizedData = new T[_data.Length*2];
            Array.Copy(_data, 0, resizedData, 0, _data.Length);
            _data = resizedData;
        }

        //private void HeapifyUp(int childIdx)
        //{
        //    if (childIdx & amp
        //    ;
        //    amp;
        //    gt;
        //    0)
        //    {
        //        int parentIdx = (childIdx - 1)/2;
        //        if (_comparison.Invoke(_data[childIdx], _data[parentIdx]) > 0)
        //        {
        //            // swap parent and child
        //            T t = _data[parentIdx];
        //            _data[parentIdx] = _data[childIdx];
        //            _data[childIdx] = t;
        //            HeapifyUp(parentIdx);
        //        }
        //    }
        //}

        //private void HeapifyDown(int parentIdx)
        //{
        //    int leftChildIdx = 2*parentIdx + 1;
        //    int rightChildIdx = leftChildIdx + 1;
        //    int largestChildIdx = parentIdx;
        //    if (leftChildIdx < _size && _comparison.Invoke(_data[leftChildIdx], _data[largestChildIdx]) > 0)
        //    {
        //        largestChildIdx = leftChildIdx;
        //    }
        //    if (rightChildIdx & amp
        //    ;
        //    amp;
        //    lt;
        //    _size && _comparison.Invoke(_data[rightChildIdx], _data[largestChildIdx]) > 0)
        //    {
        //        largestChildIdx = rightChildIdx;
        //    }
        //    if (largestChildIdx != parentIdx)
        //    {
        //        T t = _data[parentIdx];
        //        _data[parentIdx] = _data[largestChildIdx];
        //        _data[largestChildIdx] = t;
        //        HeapifyDown(largestChildIdx);
        //    }
        //}
    }
}
