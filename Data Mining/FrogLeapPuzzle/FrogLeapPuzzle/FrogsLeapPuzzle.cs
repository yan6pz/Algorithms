using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogLeapPuzzle
{
    public class FrogsLeapPuzzle
    {
        public int[] Frogs { get; set; }
        //private bool[] marked;
        //public int Counter { get; set; }
        //public int MinimumLeapsToEnd { get; set; }
        public Stack<string> States { get; set; }
        public FrogsLeapPuzzle(int frogsPerSide)
        {
            var frogSize = 2 * frogsPerSide + 1;
            this.Frogs = new int[frogSize];
            for (int i = 0; i < frogsPerSide; i++)
            {
                this.Frogs[i] = 1;
                this.Frogs[frogSize - i - 1] = 2;

            }
            this.States = new Stack<string>();
            // the number of moves with n frogs a side must be  (n + 1)^2 - 1
            //this.MinimumLeapsToEnd = (int)Math.Pow(frogsPerSide + 1,2)  - 1;
            var findPermutations = Permute(Frogs, frogsPerSide);
            while (this.States.Count != 0)
            {
                ShowStateStack(this.States.Pop());
            }
            

        }

        public bool Permute(int[] state, int zeroPosition)
        {
            if (/*Counter>=this.MinimumLeapsToEnd &&*/ areFrogsOrdered(state))
            {
                return true;
            }
            
            if (zeroPosition - 1 >= 0 && state[zeroPosition - 1] == 1)
            {
                Swap(ref state[zeroPosition], ref state[zeroPosition - 1]);
                //Counter++;
                if (Permute(state, zeroPosition - 1))
                {

                    States.Push(string.Join(", ", state));
                    Swap(ref state[zeroPosition], ref state[zeroPosition - 1]);
                    
                    return true;
                }
                //Counter--;
                Swap(ref state[zeroPosition], ref state[zeroPosition - 1]);
            }

            if (zeroPosition - 2 >= 0 && state[zeroPosition - 2] == 1)
            {
                Swap(ref state[zeroPosition], ref state[zeroPosition - 2]);
                //Counter++;
                if (Permute(state, zeroPosition - 2))
                {
                    States.Push(string.Join(", ", state));
                    Swap(ref state[zeroPosition], ref state[zeroPosition - 2]);
                    return true;
                }
                //Counter--;
                Swap(ref state[zeroPosition], ref state[zeroPosition - 2]);
            }
            //first right neighbour to the zero
            if (zeroPosition + 1 < state.Length && state[zeroPosition + 1] == 2)
            {
                Swap(ref state[zeroPosition], ref state[zeroPosition + 1]);
                //Counter++;
                if (Permute(state, zeroPosition + 1))
                {
                    States.Push(string.Join(", ", state));
                    Swap(ref state[zeroPosition], ref state[zeroPosition + 1]);
                    return true;
                }
                //Counter--;
                Swap(ref state[zeroPosition], ref state[zeroPosition + 1]);
            }
            //second right neighbour to the zero
            if (zeroPosition + 2 < state.Length && state[zeroPosition + 2] == 2)
            {
                Swap(ref state[zeroPosition], ref state[zeroPosition + 2]);
                // Counter++;
                if (Permute(state, zeroPosition + 2))
                {
                    States.Push(string.Join(", ", state));
                    Swap(ref state[zeroPosition], ref state[zeroPosition + 2]);
                    return true;
                }
                //Counter--;
                Swap(ref state[zeroPosition], ref state[zeroPosition + 2]);
            }

            return false;
        }

        private void ShowState(int[] state)
        {
            Console.WriteLine(string.Join(", ", state));
        }


        private void ShowStateStack(string state)
        {
            Console.WriteLine(state);
        }

        private void Swap(ref int v1, ref int v2)
        {
            var temp = v1;
            v1 = v2;
            v2 = temp;
        }
        private bool areFrogsOrdered(int[] frogs)
        {
            if (frogs[frogs.Length / 2] != 0)
                return false;

            for (int i = 0; i < frogs.Length / 2; i++)
            {
                if (frogs[i] != 2)
                    return false;

            }
            return true;
        }
    }
}
