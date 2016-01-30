using System;
using System.Collections.Generic;
using System.Linq;

namespace NPuzzle
{
    public class EightPuzzle
    {
        public byte[] Goal { get; set; }

        public C5.IntervalHeap<Node> Queue { get; set; }
        public HashSet<Node> ClosedList { get; set; }

        public EightPuzzle(byte[] goal)
        {
            this.Goal = goal;
            this.Queue = new C5.IntervalHeap<Node>();
            this.ClosedList = new HashSet<Node>();

        }
        

        public void Rearange(byte[] InpuArray)
        {

            this.Queue.Add(new Node(InpuArray));

            while (this.Queue.Count>0)
            {

                Node state = this.Queue.DeleteMin();

                if (IsGoal(state.Elements))
                {
                    Console.WriteLine(  state.Count());
                    return;
                }


                this.ClosedList.Add(state);
                //if zero is down from 0,1,2 go up
                if(state.ZeroIndex>2)
                    AddElementIfNotTraversed(new Node(state, state.ZeroIndex - 3));
                //if zero is upper from 6,7,8 go down
                if(state.ZeroIndex<6)
                    AddElementIfNotTraversed(new Node(state, state.ZeroIndex + 3));
                //if zero is in the right of 0,3,6 go left
                if(state.ZeroIndex%3>0)
                    AddElementIfNotTraversed(new Node(state, state.ZeroIndex - 1));
                //if the zero is left from 2,5,8 go right
                if(state.ZeroIndex%3<2)
                    AddElementIfNotTraversed(new Node(state, state.ZeroIndex + 1));
            }
        }

        void AddElementIfNotTraversed(Node successor)
        {
            if (!this.ClosedList.Contains(successor))
                this.Queue.Add(successor);
        }

        bool IsGoal(byte[] elements)
        {
            return Enumerable.SequenceEqual(elements, this.Goal);
        }

    }
}