using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
           /*byte[] InpuArray = { 6, 5, 3, 2, 4, 8, 7, 0, 1 };
            new Test().solve(InpuArray);*/

            byte[] InpuArray = { 6,5,3,2,4,8,7,0,1};
            //byte[] InpuArray = { 2,3,6,1,5,8,4,7,0};
            byte[] goalList = {  1, 2, 3, 4, 5, 6, 7, 8 ,0};
            var eightPuzzle=new EightPuzzle(goalList);
            eightPuzzle.Rearange(InpuArray);
        }
    }
}
