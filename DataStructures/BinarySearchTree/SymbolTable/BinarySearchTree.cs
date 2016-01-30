using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolTable
{
   public class BinarySearchTree<T ,P> where P: IComparable

   {
       private Node<T,P> root;
       public IEnumerable<P> levelOrder()
       {
           var keys = new Queue<P>();
           var queue = new Queue<Node<T, P>>();
           queue.Enqueue(root);
           while (queue.Count != 0)
           {
               Node<T, P> x = queue.Dequeue();
               if (x == null) continue;
               keys.Enqueue(x.key);
               queue.Enqueue(x.left);
               queue.Enqueue(x.right);
           }
           return keys;
       }

       public T Get(P key)
       {
           Node<T, P> x = root;
           while (x != null)
           {
               var cmp = key.CompareTo(x.key);
               if (cmp < 0)
                   x = x.left;
               else if (cmp > 0)
                   x = x.right;
               else
               {
                   return x.value;
               }
               
           }
           return default(T);
       }
       public void Delete(P key)
       {
           root = Delete(root, key);
       }
       private Node<T, P> Delete(Node<T, P> node, P key)
       {
           if (node == null)
               return null;
           var cmp = key.CompareTo(node.key);
           if (cmp < 0)
               node.left = Delete(node.left, key);
           else if (cmp > 0)
               node.right = Delete(node.right, key);
           else
           {
               if (node.left == null)
                   return node.right;
               if (node.right == null)
                   return node.left;
               Node<T, P> t = node;
               node = Min(t.right);
               node.right = DeleteMin(t.right);
               node.left = t.left;
           }
           return node;
       }

       private Node<T, P> Min(Node<T, P> right)
       {
           if (right == null)
               return null;
           if (right.left == null)
               return right;
           return Min(right.left);

       }

       private Node<T, P> DeleteMin(Node<T, P> right)
       {
           if (right.left == null)
               return right.right;
           right.left = DeleteMin(right.left);
           return right;
       }

       public void Put(T value, P key)
       {
           root=Put(root, value, key);
       }
        public IEnumerable<P> Keys()
        {
            var q=new Queue<P>();
            Inorder(root, q);
            return q;
        }

       private void Inorder(Node<T, P> node, Queue<P> queue)
       {
           if (node == null)
               return;
           Inorder(node.left,queue);
           queue.Enqueue(node.key);
           Inorder(node.right,queue);
       }

       private Node<T, P> Put(Node<T, P> x, T value, P key)
       {
           if(x==null) 
               return new Node<T, P>(value,key);
           var cmp = key.CompareTo(x.key);
           if (cmp < 0)
               x.left = Put(x.left, value, key);
           else if (cmp > 0)
               x.right = Put(x.right, value, key);
           else
           {
                x.value=value;
           }
           return x;
       }
    }
}
