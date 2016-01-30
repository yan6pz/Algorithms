using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
   public class BinaryHeap<T> where T:IComparable 
   {
       public T[] PQ;
       protected int N = 0;

       public BinaryHeap(int capacity)
       {
           PQ = new T[capacity+1];
       }
       public void Insert(T key)
       {
           PQ[++N] = key;
           Swim(N);
       }

       public T DeleteMax()
       {
           T max = PQ[1];
           Exchange(1,N--);
           Sink(1);
           PQ[N+1] = default(T);
           return max;
       }
       private bool IsEmpty()
       {
           return N == 0;
       }
       private void Sink(int k)
       {
           while (2*k <= N)
           {
               int j = 2*k;
               if (j < N && Less(PQ[j], PQ[j + 1]))
                   j++;
               if (!Less(PQ[k], PQ[j]))
                   break;
               Exchange(k,j);
               k = j;
           }
       }
       private void Swim(int k)
       {
           while (k > 1 && Less(PQ[k / 2], PQ[k]))
           {
               Exchange(k, k/2);
               k = k/2;
           }
       }

       private void Exchange(int i, int j)
       {
           T temp = PQ[i];
           PQ[i] = PQ[j];
           PQ[j] = temp;
       }

       private  bool Less(IComparable i, IComparable j)
       {
           var result = i.CompareTo(j);
           return result < 0;
       }
       public override string ToString()
       {
           string res = "";
          
           foreach (var el in PQ)
           {
               if( el is Integer)
               res += el + " ";
           }
           return res;
       }

    }
}
