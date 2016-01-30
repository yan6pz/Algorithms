using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NPuzzle
{
    public class Node : IComparable<Node>
    {
        public byte[] Elements { get; set; }

        public int ZeroIndex { get; set; }
     
        public int G { get; set; }
        public int H { get; set; }
        //calculate F value
        public int Priority
        {
            get
            {
                return this.G + this.H;
            }
            set { }
        }
        public Node Parent { get; set; }

        public Node(byte[] InpuArray)
        {
            this.Elements = InpuArray;
            
            ZeroIndex = Array.IndexOf<byte>(this.Elements,0);
            this.G = 0;
            this.H = Heuristic(this.Elements);
            Parent = null;
        }

        public Node(Node parent, int slideFromIndex)
        {
            this.Elements = new byte[parent.Elements.Length];
            Array.Copy(parent.Elements, this.Elements, parent.Elements.Length);
            SwapZeroElement(parent.ZeroIndex, slideFromIndex);
            this.G = parent.G + 1;
            this.H = Heuristic(this.Elements);
            this.Parent = parent;
        }

        private void SwapZeroElement(int zeroIndex, int slideFromIndex)
        {
            var temp = this.Elements[zeroIndex];
            this.Elements[zeroIndex] = this.Elements[slideFromIndex];
            this.Elements[slideFromIndex] = temp;
            this.ZeroIndex = slideFromIndex;
        }

        private int Heuristic(byte[] elements)
        {
            int h = 0;
            for (int i = 0; i < elements.Length; i++)
                if (elements[i] != 0)
                    h += Distance(i, elements[i]);
            return h;
        }

        private int Distance(int a, int b)
        {
            return Math.Abs(a / 3 - b / 3) + Math.Abs(a % 3 - b % 3);
        }

        public int Count()
        {
            var count = 1;
            while(this.Parent.Parent!=null)
            {
                this.Parent = this.Parent.Parent;
                count++;
            }
           
             return  count;

        }
        

        public int CompareTo(Node other)
        {
            return this.Priority - other.Priority;
        }

        public override bool Equals(object obj)
        {
            Node other = obj as Node;
            if(other!=null)
                return Enumerable.SequenceEqual(this.Elements, other.Elements);
            
            return false;
        }

        public override int GetHashCode()
        {

            if (this.Elements == null || this.Elements.Length == 0)
                return 0;
            var hashCode = 0;
            for (var i = 0; i < this.Elements.Length; i++)
                // Rotate by 3 bits and XOR the new value.
                hashCode = (hashCode << 3) | (hashCode >> (29)) ^this.Elements[i];
            return hashCode;
        }
    }
}
