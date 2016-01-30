using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogLeapPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int frogsPerSide = int.Parse(Console.ReadLine());
            var watch = new Stopwatch();
            watch.Start();
            var puzzle = new FrogsLeapPuzzle(frogsPerSide);
            watch.Stop();
            //Console.WriteLine(watch.Elapsed);
        }
    }
}
