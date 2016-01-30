using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    public class NQueens
    {
        private Random randomize = new Random();
        public int[] Rows { get; set; }

        public NQueens(int n)
        {
            this.Rows = new int[n];
            FillField();        
        }

        public NQueens(int n,bool isFormulas)
        {
            this.Rows = new int[n];
            FillDiagonalF();
        }


        public void FindNonConflictsChessboard()
        {
            var maxConflictElements = new List<int>();

            var minConflictElements = new List<int>();

            int maxConflictsCount= FindMaxConflicts(maxConflictElements, 0);
            while ( maxConflictsCount != 0)
            {
                maxConflictsCount = 0;
                maxConflictElements.Clear();

                maxConflictsCount = FindMaxConflicts(maxConflictElements, 0);

                int mostConflictsColumn = maxConflictElements.ElementAt(randomize.Next(maxConflictElements.Count));

                FindMinConflictsAmongTheMax(minConflictElements, mostConflictsColumn);

                if (minConflictElements.Count > 0)
                {
                    Rows[mostConflictsColumn] =
                            minConflictElements.ElementAt(randomize.Next(minConflictElements.Count));
                }
            }
        }

        public void FormulaApproach()
        {
            if (Rows.Length % 6 != 2 && Rows.Length % 6 != 3)
            {
                int j=0,p=0;
                for (int i = 0; i < Rows.Length; i++)
                {
                    if (i % 2 != 0)
                        Rows[p++] = i+1;
                    else
                        Rows[Rows.Length/2 + j++] = i+1;
                }
            }
            else
            {
                var even = new int[Rows.Length / 2];
                int[] odd;
                if (Rows.Length % 6 == 3)
                {
                     odd = new int[Rows.Length / 2+1];
                }
                else
                {
                    odd = new int[Rows.Length / 2];
                }


                int p = 0, q = 0;
                for (int i = 1; i <= Rows.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        even[p++] = i;
                    }
                    else
                    {
                        odd[q++] = i;
                    }
                }
                if (Rows.Length % 6 == 2)
                {
                    Swap1(ref odd[0], ref odd[1]);
                    var temp = odd[2];
                    for (int i = 2; i < odd.Length - 1; i++)
                    {
                        odd[i] = odd[i + 1];
                    }
                    odd[odd.Length - 1] = temp;

                    /*for (int i = 0; i < even.Length; i++)
                    {
                        Rows[i] = even[i];
                    }
                    int j = 0;
                    for (int i = odd.Length; i < Rows.Length; i++)
                    {
                        Rows[i] = odd[j++];
                    }*/
                }
                if (Rows.Length % 6 == 3)
                {
                    var temp = even[0];
                    for (int i = 0; i < even.Length-1; i++)
                    {
                        even[i] = even[i + 1];
                    }
                    even[even.Length-1] = temp;
                    var odd1 = odd[0];
                    var odd2 = odd[1];
                    for (int i = 0; i < odd.Length-2; i++)
                    {
                        odd[i] = odd[i + 2];
                       
                    }

                    odd[odd.Length - 2] = odd1;
                    odd[odd.Length-1] = odd2;

                    
                }
                Rows = even.Concat(odd).ToArray();

            }
        }

        private void Swap1(ref int a,ref  int b)
        {
            int c = a;
           a = b;
            b = c;
        }

        private void FillField()
        {
            FillDiagonal();
            // GetResult();

            SwapRandomly();
            //GetResult();
        }

        private void SwapRandomly()
        {
            for (int i = 0; i < Rows.Length; i++)
            {
                int j = randomize.Next(0, Rows.Length);
                Swap(i, j);
            }
        }

        private void FillDiagonal()
        {
            //first all queens to the prime diagonal
            for (int i = 0; i < Rows.Length; i++)
            {
                Rows[i] = i;
            }
        }

        private void FillDiagonalF()
        {
            //first all queens to the prime diagonal
            for (int i = 0; i < Rows.Length; i++)
            {
                Rows[i] = i+1;
            }
        }

        private void Swap(int i, int j)
        {
            int rowToSwap = Rows[i];
            Rows[i] = Rows[j];
            Rows[j] = rowToSwap;
        }

        private int FindConflictsNumber(int row, int column)
        {    
            int count = 0;

            for (int c = 0; c < Rows.Length; c++)
            {
                if (c == column)
                {
                    continue;
                }
                int r = Rows[c];
                if (r == row || Math.Abs(r - row) == Math.Abs(c - column))
                {
                    count++;
                }
            }
            return count;
        }

        private int FindMinConflictsAmongTheMax(List<int> elements, int mostConflictsColumn)
        {
            int minConflictsCount = Rows.Length;
            for (int r = 0; r < Rows.Length; r++)
            {
                int conflicts = this.FindConflictsNumber(r, mostConflictsColumn);
                if (conflicts == minConflictsCount)
                {
                    elements.Add(r);
                }
                else if (conflicts < minConflictsCount)
                {
                    minConflictsCount = conflicts;
                    elements.Clear();
                    elements.Add(r);
                }
            }

            return minConflictsCount;
        }

        private int FindMaxConflicts(List<int> elements, int maxConflictsCount)
        {
            for (int c = 0; c < Rows.Length; c++)
            {
                int conflicts = this.FindConflictsNumber(Rows[c], c);
                if (conflicts == maxConflictsCount)
                {
                    elements.Add(c);
                }
                else if (conflicts > maxConflictsCount)
                {
                    maxConflictsCount = conflicts;
                    elements.Clear();
                    elements.Add(c);
                }
            }

            return maxConflictsCount;
        }

        public void GetResult()
        {
            foreach (var row in Rows)
            {
                foreach (var col in Rows)
                {
                    Console.Write(row== Rows[col]?'Q':'-');
                }
                Console.WriteLine();
            }
        }

        public void GetResultF()
        {
            foreach (var row in Rows)
            {
                foreach (var col in Rows)
                {
                    Console.Write(row == Rows[col-1] ? 'Q' : '-');
                }
                Console.WriteLine();
            }
        }
    }
}
