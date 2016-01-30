using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolTable
{
    class Program
    {
        private static Integer[] array = new Integer[] { new Integer(56), new Integer(12)
            , new Integer(69), new Integer(27), new Integer(16), new Integer(40), new Integer(14)
                , new Integer(52), new Integer(41), new Integer(71) };
        private static Integer[] arrayDel = new Integer[] { new Integer(49), new Integer(33)
            , new Integer(75), new Integer(32), new Integer(40), new Integer(86), new Integer(15)
                , new Integer(38), new Integer(45), new Integer(83), new Integer(12), new Integer(31) };
        static void Main(string[] args)
        {
            var bst=new BinarySearchTree<string, int>();
            for (int i = 0; i < array.Length; i++)
            {
                bst.Put(i.ToString(), array[i].data);
            }
            Console.WriteLine(bst.levelOrder());

            var bst2 = new BinarySearchTree<string, int>();
            for (int i = 0; i < arrayDel.Length; i++)
            {
                bst2.Put(i.ToString(), arrayDel[i].data);
            }
            bst2.Delete(83);
            bst2.Delete(75);
            bst2.Delete(33);
            Console.WriteLine(bst2.levelOrder());


        }
    }
}
