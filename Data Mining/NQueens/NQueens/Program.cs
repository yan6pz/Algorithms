using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfQueens = int.Parse(Console.ReadLine());

            //var chessBoard = new NQueens(numberOfQueens);
            //chessBoard.FindNonConflictsChessboard();
            //chessBoard.GetResult();
            var chessBoard = new NQueens(numberOfQueens,true);
            chessBoard.FormulaApproach();
            chessBoard.GetResultF();
        }
    }
}
