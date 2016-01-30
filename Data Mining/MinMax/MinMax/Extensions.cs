using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMax
{
    public static class Extensions
    {
        public static string ToStringBoard(this int[][] board)
        {
            var move = new StringBuilder();
            for (int j = 0; j < board.Length; j++)
            {
                for (int k = 0; k < board.Length; k++)
                {
                    move.Append(board[j][k]);
                }
            }
            return move.ToString();
        }

        public static int[][] ToInt(this string board)
        {
            var boardInt = new int[3][];
            var charBoard = board.ToCharArray();
            for (int i = 0; i < 3; i++)
            {
                boardInt[i] = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    boardInt[i][j] = board[i * 3 + j] - '0';
                }
            }
            return boardInt;
        }

        public static int[][] CopyArray(this int[][] board)
        {
            var newArray = board.Select(a => a.ToArray()).ToArray();

            return newArray;
        }

    }
}
