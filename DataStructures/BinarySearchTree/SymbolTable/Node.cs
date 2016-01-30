using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolTable
{
    public class Node<T,P>  
    {
        public Node<T,P> left, right;
        public T value;
        public P key;

        public Node(T val,P key)
        {
            this.value = val;
            this.key = key;
        }
    }
}
